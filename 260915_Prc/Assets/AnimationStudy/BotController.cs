using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{
    //private Animator _animator;

    public event Action<bool> OnMove;
    public event Action OnAttack;

    //private void Awake()
    //{
    //    CacheComponents();
    //}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            MoveStart();

        if(Input.GetKeyUp(KeyCode.W))
            MoveEnd();

        if (Input.GetKeyDown(KeyCode.Space))
            Attack();
    }

    private void MoveStart()
    {
        Debug.Log("이동 시작");
        //_animator.SetBool("IsMove", true);
        OnMove?.Invoke(true);
    }

    private void MoveEnd()
    {
        Debug.Log("이동 종료");
        //_animator.SetBool("IsMove", false);
        OnMove?.Invoke(false);
    }

    private void Attack()
    {
        Debug.Log("꽁껶");
        //_animator.SetTrigger("Attack");
        OnAttack?.Invoke();
    }

    //private void CacheComponents()
    //{
    //    _animator = GetComponent<Animator>();
    //}
}
