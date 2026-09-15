using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    private Transform _cameraTransform;

    [SerializeField] private KeyCode _fireKey = KeyCode.Mouse0;
    [SerializeField] private float _range;
    [SerializeField] private int _damage;
    private bool _isPressedFire => Input.GetKey(_fireKey);
    private bool _canFire => _isPressedFire && !_isNotRdyFire && !_isEmptyMagazine && !_isReloading;

    [SerializeField] private LayerMask _targetLayer;

    // --------- 재장전 -----------
    // R키로 30발 재장전
    [SerializeField] private KeyCode _reloadKey = KeyCode.R;
    // 탄알집에 30발 들어갈 수 있다고 가정
    [SerializeField] private int _magazineCount;
    // 30발 소진 시 총 안쏴짐
    private int _currentMagazineCount;
    private bool _isEmptyMagazine => _currentMagazineCount <= 0;
    private bool _isPressedReload => Input.GetKeyDown(_reloadKey);

    public int CurrentMagazine => _currentMagazineCount;
    public int MaxMagazine => _magazineCount;
    // 재장전 탄환은 무제한
    // 리로드 기능 함수
    public void Reload()
    {
        if (!_isPressedReload)
              return;
        
        StartCoroutine(ReloadRoutine());
    }
    // -------- 개선된 재장전 (코루틴) --------//
    [SerializeField] private float _reloadDelay;
    private bool _isReloading;
    public IEnumerator ReloadRoutine()
    {
        _isReloading = true;
        yield return new WaitForSeconds(_reloadDelay);

        _currentMagazineCount = _magazineCount;
        Debug.Log($"{_magazineCount}발 재장전 되었습니다.");
        _isReloading = false;
    }
    // -----------------------------------

    // ------------------------------------------
    private void Awake()
    {
        CacheComponents();
        // +
        FireRoutineSetter();
    }
    private void Start()
    {
        Init();
    }
    // ------------------------------------------

    public void Fire()
    {
        if (!_canFire) return;

        StartCoroutine(FireRoutine());
        // 발사 시 현재 탄환 수 감소
        _currentMagazineCount--;
        //_currentCooldown = 0f;
        FlameEffect();

        if (!TryGetDamageable(out IDamagable damagable)) return;

        damagable.TakeDamage(_damage);

        // TODO: 실제 구현 완료되면 로그출력 삭제
        Debug.Log($"Player : {damagable.gameObject.name}에게 발사");
        Debug.Log($"Player : {_currentMagazineCount}발 남음.");
    }

    // Raycast가 어디인가 맞았을 때 판단 가능.
    private bool TryGetDamageable(out IDamagable damageable)
    {
        bool result = false;
        damageable = null;

        Ray ray = new Ray(_cameraTransform.position, _cameraTransform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _range, _targetLayer))
        {
            ShotEffect(hit);
            result = hit.transform.TryGetComponent(out damageable);
        }

        return result;
    }

    private void CacheComponents()
    {
        _cameraTransform = Camera.main.transform;
    }

    private void Init()
    {
        _currentMagazineCount = _magazineCount;
    }

    // ------ 개선된 사격 쿨타임(캐싱 코루틴) ---------//
    // 상시 돌아가는 것
    // 쿨다운 적용해야 할 때까지 기다렸다가 수행하고 다시 대기
    [SerializeField] private float _fireCool;
    private WaitForSeconds _fireWaitSec;
    private bool _isNotRdyFire;

    private void FireRoutineSetter()
    {
        _fireWaitSec = new WaitForSeconds(_fireCool);
    }

    public IEnumerator FireRoutine()
    {
        _isNotRdyFire = true;
        yield return _fireWaitSec;
        _isNotRdyFire = false;
    }
    // -------------------------------------------------//
    // 이펙트
    [SerializeField] private FlameEffect _flameEffect;

    private void FlameEffect()
    {
        _flameEffect.gameObject.SetActive(true);
        _flameEffect.Play();
    }

    // 탄착군
    [SerializeField] private FlameEffect _shotEffect;

    // RaycastHit를 받아서 Transform. 
    private void ShotEffect(RaycastHit hit)
    {
        Transform effectTransform = Instantiate(_shotEffect).transform;

        effectTransform.position = hit.point;
        // 원하는 벡터가 들어갈 수 있음.
        effectTransform.forward = hit.normal;
    }
}
