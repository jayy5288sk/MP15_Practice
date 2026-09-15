using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour, IDamagable
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
        Debug.Log($"{gameObject.name}: 데미지 {damage} 피격받음.");
        _currentHp -= damage;
    }

    private void Init()
    {
        _currentHp = maxHp;
    }

    private void Dead()
    {
        if( _currentHp <= 0 )
        {
            Destroy(gameObject);
        }
    }
}
