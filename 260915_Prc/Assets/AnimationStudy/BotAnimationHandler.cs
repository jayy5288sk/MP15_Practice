using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotAnimationHandler : MonoBehaviour
{
    [SerializeField] private string _moveAnimParam;
    [SerializeField] private string _attackAnimParam;

    private int _move;
    private int _attack;

    private BotController _controller;
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
        _controller.OnAttack += SetAttackAnim;
    }

    private void UnbindEvents()
    {
        _controller.OnMove -= SetMoveAnim;
        _controller.OnAttack -= SetAttackAnim;
    }

    private void SetMoveAnim(bool isMove)
    {
        _animator.SetBool(_move, isMove);
    }

    private void SetAttackAnim()
    {
        _animator.SetTrigger(_attack);
    }
    private void Init()
    {
        _move = Animator.StringToHash(_moveAnimParam);
        _attack = Animator.StringToHash(_attackAnimParam);
    }

    private void CacheComponents()
    {
        _controller = GetComponent<BotController>();
        _animator = GetComponent<Animator>();
    }
}
