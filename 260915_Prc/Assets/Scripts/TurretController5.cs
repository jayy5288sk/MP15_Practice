using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController5 : MonoBehaviour
{
    [SerializeField] private LayerMask _targetLayer;
    private TurretDetectionTrigger _detectionTrigger;
    private Transform _playerTransform => _detectionTrigger.TargetTransform;
    private SphereCollider _sphereCollider;
    private bool _isPlayerInTrigger { get { return _playerTransform != null; } }
    private bool _isPlayerInsight = false;

    [SerializeField] private Transform _muzzlePoint;

    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Transform _headTransform;

    //[SerializeField] private float _cooldown;
    //private float _currentCooldown;
    //private bool _isReadyToFire { get { return _currentCooldown >= _cooldown; } }

    [Header("Bullet")]
    [SerializeField] private BulletControll _bulletPrefab;
    [SerializeField] private int _bulletDamage;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _returnDelay;

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
        //UpdateCurrentCooldown();
    }

    private void CacheComponents()
    {
        //_sphereCollider = GetComponent<SphereCollider>();
        // + 
        _sphereCollider = GetComponentInChildren<SphereCollider>();
        _detectionTrigger = GetComponentInChildren<TurretDetectionTrigger>();
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
        if (!_isPlayerInsight || !_isPlayerInTrigger)
        {
            return;
        }

        Vector3 look = new Vector3(
            _playerTransform.position.x,
            _headTransform.position.y,
            _playerTransform.position.z
            );

        _headTransform.LookAt(look);

        // 발사.
        //if (!_isReadyToFire)
        //    return;
        // + 코루틴 적용
        if (_isNotCannonShot)
            return;

        StartCoroutine(CannonFireRoutine());

        SpawnBullet();

        //_currentCooldown = 0f;
    }

    //private void UpdateCurrentCooldown()
    //{
    //    if (_isReadyToFire)
    //    {
    //        return;
    //    }
    //    _currentCooldown += Time.deltaTime;
    //}

    // --------- 개선된 사격 간격(코루틴) -------- //
    [SerializeField] private float _cannonShotDelay;
    private bool _isNotCannonShot;
    public IEnumerator CannonFireRoutine()
    {
        _isNotCannonShot = true;
        yield return new WaitForSeconds(_cannonShotDelay);
        _isNotCannonShot = false;
    }
    // -------------------------------------------- //
    [SerializeField] private ObjectPool _bulletPool;

    private void SpawnBullet()
    {
        // 1. 얻어오기 
        IPoolable bullet = _bulletPool.Take();

        // 2. Transform.pos, rot 설정
        if (bullet == null)
            return;

        bullet.tr.position = _muzzlePoint.position;
        bullet.tr.rotation = _muzzlePoint.rotation;

        // 3. 활성화
        bullet.tr.gameObject.SetActive(true);

        //SetData - 연산이 적은 방식
        (bullet as BulletControll).SetData(_bulletDamage, _bulletSpeed, _returnDelay);

        //if (!TryGetDamageable(out IDamagable damagable))
        //    return;

        //damagable.TakeDamage(_bulletDamage);
    }

    private void RayShotToPlayer()
    {
        _isPlayerInsight = false;

        if (!_isPlayerInTrigger)
        {
            return;
        }

        Vector3 from = new Vector3(transform.position.x,
                       transform.position.y + _muzzlePoint.position.y,
                       transform.position.z
                        );


        Vector3 to = new Vector3(_playerTransform.position.x,
                     _playerTransform.position.y + _muzzlePoint.position.y,
                     _playerTransform.position.z
                      );

        Ray ray = new Ray(from, (to - from).normalized);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _sphereCollider.radius, _targetLayer))
        {
            if (hit.transform != _playerTransform)
                return;

            _isPlayerInsight = true;
        }
    }

    private bool TryGetDamageable(out IDamagable damageable)
    {
        bool result = false;
        damageable = null;

        Ray ray = new Ray(_muzzlePoint.position, _muzzlePoint.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _sphereCollider.radius, _targetLayer))
        {
            result = hit.transform.TryGetComponent(out damageable);
        }

        return result;
    }
}
