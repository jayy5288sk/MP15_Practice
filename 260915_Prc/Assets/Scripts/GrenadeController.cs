using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeController : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private int _damage;
    [SerializeField] private float _knockbackForce;
    
    private float _explosiveTime = 3f;
    private float _elapseTime;
    private SphereCollider _sphereCol;

    private void Awake()
    {
        CacheComponents();
    }

    private void Update()
    {
        
    }

    private void CacheComponents()
    {
        _sphereCol = GetComponent<SphereCollider>();

    }

    private void Explosion()
    {
        
    }

    private void UpdateExplosiveTime()
    {
        _elapseTime += Time.deltaTime;
    }
}
