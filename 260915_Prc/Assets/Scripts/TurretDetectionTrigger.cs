using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDetectionTrigger : MonoBehaviour
{
    [SerializeField] private LayerMask _targetLayer;

    private SphereCollider _detectCollider;

    public Transform TargetTransform { get; private set; }

    private void Awake()
    {
        CacheComponents();
    }

    private void OnTriggerEnter(Collider other)
    {
        DetectTarget(other);
    }

    private void OnTriggerExit(Collider other)
    {
        UndetectedTarget(other);  
    }

    private void CacheComponents()
    {
        _detectCollider = GetComponent<SphereCollider>();
    }

    private void DetectTarget(Collider collider)
    {
        if (!_targetLayer.Contains(collider))
            return;

        TargetTransform = collider.transform;
    }

    private void UndetectedTarget(Collider collider)
    {
        if(!_targetLayer.Contains(collider)) 
            return;

        TargetTransform = null;
    }
}
