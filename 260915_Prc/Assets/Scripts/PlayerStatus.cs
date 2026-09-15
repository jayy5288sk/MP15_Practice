using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour, IDamagable
{
    public GameObject getObject { get => this.gameObject; }
    [SerializeField] private int maxHp;
    private int _currentHp;

    public int CurrentHp => _currentHp;
    public int MaxHp => maxHp;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        Dead();
    }

    public void TakeDamage(int damage)
    {
        _currentHp -= damage;
        Debug.Log($"{_currentHp} Remain.");
    }

    private void Init()
    {
        _currentHp = maxHp;
    }

    private void Dead()
    {
        if (_currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
