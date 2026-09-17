using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController2 : MonoBehaviour
{
    public event Action<Vector2> OnMove;
    private Vector2 _prevMovement;

    private void Update() => SetMove();

    private void SetMove()
    {
        Vector2 movement = GetMovement();
        // 이전 프레임의 Movement와 같으면 return
        if (_prevMovement == movement)
            return;

        // 다르다면 OnMove + _prevMovement
        OnMove?.Invoke(movement);

        // 갱신
        _prevMovement = movement;
    }
    private Vector2 GetMovement()
    {
        // 입력받아서 Vector2 반환.=> GetAxisRaw
        // 단위벡터로 만들지 말 것. 
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
