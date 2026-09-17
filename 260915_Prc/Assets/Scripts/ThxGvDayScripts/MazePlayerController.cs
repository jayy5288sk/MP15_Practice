using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazePlayerController : MonoBehaviour
{
    // ---- 기본 이동 구현 ---- //
    public event Action<Vector2> OnMove;
    private Vector2 _prevMovement;

    private void Update()
    {
        SetInputMove();
    }

    private void SetInputMove()
    {
        Vector2 currentMovement = GetInputMove();

        if (currentMovement == _prevMovement)
        {
            return;
        }

        OnMove?.Invoke(currentMovement);

        _prevMovement = currentMovement;
    }

    private Vector2 GetInputMove()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    // ---- 상호작용 관련 ---- //
    [SerializeField] private KeyCode _InteractionKey = KeyCode.F;
    private bool _isInteract;

    private void GetInputInteract()
    {

    }
}
