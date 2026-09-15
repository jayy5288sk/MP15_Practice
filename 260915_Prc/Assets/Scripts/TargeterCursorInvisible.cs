using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargeterCursorInvisible : MonoBehaviour
{
    private void Start() => LockCursor();

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
