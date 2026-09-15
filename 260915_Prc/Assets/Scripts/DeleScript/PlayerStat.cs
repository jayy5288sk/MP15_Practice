using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public Action<int> OnHealthChange;
    private int _health;
    public int Health
    {
        get => _health;

        set
        {
            _health = value;
            OnHealthChange?.Invoke(_health);
        }
    }
    public Action<float> OnMoveSpeedChange;
    private float _moveSpeed;
    public float MoveSpeed
    {
        get => _moveSpeed;

        set
        {
            _moveSpeed = value;
            OnMoveSpeedChange?.Invoke(_moveSpeed);
        }
    }
}
