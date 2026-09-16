using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IInteractor
{
    [SerializeField] private Transform _cameraPivot;
    private PlayerMovement _movement;
    private Transform _cameraTransform;

    private PlayerWeapon _weapon;

    private void Awake()
    {
        CacheComponents();
        RaycastInit();
    }

    private void Start()
    {
        LockCursor();
        StartCoroutine(RaycastRoutine());
    }

    private void Update()
    {
        //if (!GameManager.Instance.IsGameRunning)
        //    return;

        _movement.Rotate();
        _weapon.Fire();
        // + 추가됨
        _weapon.Reload();
        // ++ 추가됨
        //DetectInteractable();
        _weapon.WeaponSwap();
        TryInteract();
        // +++ 추가됨
        PauseGame();

        // ++++ 추가됨.
        if (Input.GetKeyDown(KeyCode.P))
            GameManager.Instance.Pause();
        if (Input.GetKeyDown(KeyCode.O))
            GameManager.Instance.Run();
    }

    private void FixedUpdate()
    {
        _movement.Move();
    }

    private void LateUpdate()
    {
        SetWeaponTransform();
        SetCameraTransform();
    }

    private void CacheComponents()
    {
        _movement = GetComponent<PlayerMovement>();
        _weapon = GetComponentInChildren<PlayerWeapon>();
        _cameraTransform = Camera.main.transform;
    }

    private void SetCameraTransform()
    {
        //_cameraTransform.position = _cameraPivot.position;
        //_cameraTransform.rotation = _cameraPivot.rotation;

        _cameraTransform.SetPositionAndRotation(
            _cameraPivot.position,
            _cameraPivot.rotation
            );
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void SetWeaponTransform()
    {
        _weapon.transform.SetPositionAndRotation(_cameraPivot.position,
            _cameraPivot.rotation);
    }

    // --------- IInterator -----------
    [SerializeField] private float _detectionRange;
    private IInteractable _targetInteractable;
    private bool _hasDetectInteractable => _targetInteractable != null;
    public GameObject GameObject { get => gameObject; }
    [SerializeField] private KeyCode _interactionKey = KeyCode.E;
    private bool _isPressedInteractionKey => Input.GetKeyDown(_interactionKey);
    private bool _canInteraction => _hasDetectInteractable && _isPressedInteractionKey; 

    public void DetectInteractable()
    {
        Ray ray = new Ray(_cameraTransform.position, _cameraTransform.forward);
        RaycastHit hit;

        // Raycast 실패 경우
        if (!Physics.Raycast(ray, out hit, _detectionRange))
        {
            if (_hasDetectInteractable)
            {
                _targetInteractable.Untargeting();
                _targetInteractable = null;
            }
            return;
        }

        if (_hasDetectInteractable)
        {
            // 같은 Interactable을 계속 주시하고 있는 경우
            if (hit.collider.gameObject == _targetInteractable.GameObject)
            {
                return;
            }
        }

        // 이게 null이면 실행하고 아닐때는 안한다는 것.
        _targetInteractable?.Untargeting();
        _targetInteractable = hit.collider.GetComponent<IInteractable>();

        //if (_hasDetectInteractable)
        //{
        //    Debug.Log($"{_targetInteractable.GameObject.name} 감지");
        //    _targetInteractable.Targeting();
        //}

        // 이게 null이면 실행하고 아닐때는 안한다는 것.
        _targetInteractable?.Targeting();
    }

    public void TryInteract()
    {
        if(!_canInteraction)
        { 
            return; 
        }

        //StartCoroutine(DetectableRoutine());
        _targetInteractable.Interact(this);
        _targetInteractable = null;
    }
    // ----------------------------------------------------------

    //// ----------------- 코루틴 방식의 DetectInteractable ----------------- //
    [SerializeField] private float _raycastDelay;
    private WaitForSeconds _raycastWait;
    private bool _isInteractorDetect = true;
    private void RaycastInit()
    {
        _raycastWait = new WaitForSeconds(_raycastDelay);
    }

    public IEnumerator RaycastRoutine()
    {
        while (_isInteractorDetect)
        {
            DetectInteractable();
            yield return _raycastWait;
        }
    }

    // Continue Button
    [SerializeField] private KeyCode _pauseKey = KeyCode.Escape;
    private bool _isPressedPauseKey => Input.GetKeyDown(_pauseKey);
    [SerializeField] private PlayerExitControll _playerExitControll;

    private void PauseGame()
    {
        if (_isPressedPauseKey) 
        { 
            _playerExitControll.Pause(); 
        }
    }
}
