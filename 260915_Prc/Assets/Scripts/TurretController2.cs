using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TurretController2 : MonoBehaviour
{
    // ---- 헤드 정보 ----
    public LayerMask TargetLayer;
    [SerializeField] private float _maxRayDistance;
    [SerializeField] private Transform _muzzlePoint;
    [SerializeField] private Transform _headTransform;
    [SerializeField] private float _headRotateSpeed;
    private bool _isPlayerInsight = false;
    private Vector3 _detectedPosition;


    // ---- 사격 관련 ----
    [SerializeField] private float _shotCooldown;
    private float _currentShotCooldown;
    private bool _isReadyToFire { get { return _currentShotCooldown >= _shotCooldown; } }

    // --- 총탄 관련 ---
    [Header("Bullet")]
    [SerializeField] private BulletControll _bulletPrefab; // Ins 하면서 동시에 가능
    [SerializeField] private int _bulletDamage;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _bulletDestroyDelay;

    public void Update()
    {
        Rotate();
        RayShotToPlayer();
        Fire();
        UpdateCurrentCooldown();
    }

    private void Rotate()
    {
        // 시야에 없는 상황(false)이므로
        if (_isPlayerInsight)
        {
            return;
        }

        _headTransform.Rotate(Vector3.up, _headRotateSpeed * Time.deltaTime);
    }

    private void Fire()
    {
        if (!_isPlayerInsight)
        {
            return;
        }

        Vector3 look = new Vector3(
            _detectedPosition.x,
            _headTransform.position.y,
            _detectedPosition.z
            );

        _headTransform.LookAt(look);

        // 발사.
        if (!_isReadyToFire)
            return;

        SpawnBullet();

        _currentShotCooldown = 0f;
    }

    private void SpawnBullet()
    {
        Debug.Log("탕!");
    }

    private void UpdateCurrentCooldown()
    {
        if (_isReadyToFire)
        {
            return;
        }
        _currentShotCooldown += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(TargetLayer.Contains(other))
        {
            Debug.Log("범위 안");
            _isPlayerInsight = true;
            _detectedPosition = other.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (TargetLayer.Contains(other))
        {
            Debug.Log("범위 밖");
            _isPlayerInsight = false;
        }
    }

    private void RayShotToPlayer()
    {
        Ray ray = new Ray(_muzzlePoint.transform.position, _muzzlePoint.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _maxRayDistance, TargetLayer))
        {
            //Debug.Log($"{hit.transform.name} 감지");
            //Debug.Log($"감지 범위 내 여부:{_isPlayerInsight}");
        }
    }
}
