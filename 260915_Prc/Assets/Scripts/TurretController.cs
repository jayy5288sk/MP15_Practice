using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    private Transform _playerTransform;
    //private bool _isPlayerInTrigger => _playerTransform != null;
    private bool _isPlayerInTrigger { get { return _playerTransform != null; } }
    private bool _isPlayerInsight = false;

    [SerializeField] private Transform _muzzlePoint;
    private SphereCollider _sphereCollider;

    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Transform _headTransform;

    [SerializeField] private float _cooldown;
    private float _currentCooldown;
    private bool _isReadyToFire { get { return _currentCooldown >= _cooldown; } }

    [Header("Bullet")]
    [SerializeField] private BulletControll _bulletPrefab; // Ins 하면서 동시에 가능
    [SerializeField] private int _bulletDamage;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletDestroyDelay;

    // 유니티 이벤트 
    private void Awake()
    {
        CacheComponents();
    }

    private void Update()
    {
        RayShotToPlayer();
        Rotate();
        Fire();
        UpdateCurrentCooldown();
    }

    private void CacheComponents()
    {
        _sphereCollider = GetComponent<SphereCollider>();
    }
    // ---- 끝 ----

    private void Rotate()
    {
        if (_isPlayerInsight)
        {
            return;
        }
        _headTransform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);
    }

    private void Fire()
    {
        if(!_isPlayerInsight || !_isPlayerInTrigger)
        {
            return;
        }
        Vector3 look = new Vector3(
            _playerTransform.position.x, 
            _headTransform.position.y,
            _playerTransform.position.z
            );


        //_headTransform.LookAt(_playerTransform.position);
        _headTransform.LookAt(look);

        // 발사.
        if (!_isReadyToFire)
            return;

        SpawnBullet();

        _currentCooldown = 0f;
    }

    private void UpdateCurrentCooldown()
    {
        if (_isReadyToFire)
        {
            return;
        }
        _currentCooldown += Time.deltaTime;
    }
    
    private void SpawnBullet()
    {
        //prefab > 필드 변수
        //Instantiate, pos, rot 설정
        // GetComponent<BulletControl>();
        BulletControll bullet = Instantiate(
            _bulletPrefab,
            _muzzlePoint.position,
            _muzzlePoint.rotation
            );

        //SetData
        bullet.SetData(_bulletDamage, _bulletSpeed, _bulletDestroyDelay);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("player"))
        {
            //Debug.Log("Player 범위 내 들어옴");

            _playerTransform = other.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            //Debug.Log("Player 범위 밖으로 나감");

            _playerTransform = null;
        }
    }

    private void RayShotToPlayer()
    {
        _isPlayerInsight = false;

        if (!_isPlayerInTrigger)
        {
            return;
        }

        // 각각의 피봇. 발사 위치만큼 띄워야 한다.
        Vector3 from = new Vector3(transform.position.x, 
                       transform.position.y + _muzzlePoint.position.y / 2, 
                       transform.position.z
                        );


        Vector3 to = new Vector3(_playerTransform.position.x, 
                     _playerTransform.position.y + _muzzlePoint.position.y / 2, 
                     _playerTransform.position.z
                      );
        //Ray ray;
        // 방향과 크기가 나오는 벡터로 변환 필요.
        // 목적지로 삼는 벡터에서 자신의 벡터를 빼면 다음과 같이 된다.
        Ray ray = new Ray(from, (to - from).normalized);
        RaycastHit hit;

        // 현재의 단계에서 선택할 수 있는 3가지.
        // 정석은 Layermask,
        // 발사 높이와 감지 높이를 다르게 해서 우회,
        // RaycastAll로 배열에 모두 담아서 처리

        // 반지름만큼 발사해줘야 한다. 
        if(Physics.Raycast(ray, out hit, _sphereCollider.radius))
        {
            // 플레이어를 찾았으면 감지 완료.
            // 위에 레이어마스크가 들어갈 수 있는 구간.
            if(hit.transform.CompareTag("player"))
            {
                _isPlayerInsight = true;
                //Debug.Log("Player Detected");
            }
        }
    }
}
