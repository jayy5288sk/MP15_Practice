using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotAnimationHandler2 : MonoBehaviour
{
    [SerializeField] private string _moveXParam;
    [SerializeField] private string _moveZParam;

    private int _moveX;
    private int _moveZ;

    private BotController2 _controller;
    private Animator _animator;

    private void Awake()
    {
        CacheComponents();
        Init();
    }

    private void OnEnable()
    {
        BindBotEvents();
    }

    private void OnDisable()
    {
        UnbindEvents();
    }

    private void BindBotEvents()
    {
        _controller.OnMove += SetMoveAnim;
    }

    private void UnbindEvents()
    {
        _controller.OnMove -= SetMoveAnim;
    }
    
    private void SetMoveAnim(Vector2 movement)
    {
        _animator.SetFloat(_moveX, movement.x);
        _animator.SetFloat(_moveZ, movement.y);
    }

    private void Init()
    {
        _moveX = Animator.StringToHash(_moveXParam);
        _moveZ = Animator.StringToHash(_moveZParam);
    }

    private void CacheComponents()
    {
        _controller = GetComponent<BotController2>();
        _animator = GetComponent<Animator>();
    }
}
