using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    // 자기 자신을 반환.
    public GameObject gameObject { get; }
    public void TakeDamage(int damage);
}
