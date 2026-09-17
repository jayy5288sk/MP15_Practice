using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        CacheComponents();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("player"))
        {
            _animator.SetBool("isOpen", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("player"))
        {
            _animator.SetBool("isOpen", false);
        }
    }

    private void CacheComponents()
    {
        _animator = GetComponent<Animator>();
    }
}
