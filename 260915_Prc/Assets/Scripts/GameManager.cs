using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehavior<GameManager>
{
    public bool IsGameRunning { get; private set; }

    // Singleton 사용시 이 항목만 제거.
    //public static GameManager Instance;

    private void Awake() => SetSingleton();
    //private void Start() => Run();

    public void Run()
    {
        LockCursor();
        Time.timeScale = 1;
        IsGameRunning = true;
    }

    //private void SetSingleton()
    //{
    //    if (Instance != null && Instance != this)
    //    { 
    //        Destroy(gameObject); 
    //    }
    //    else
    //    {
    //        Instance = this;
    //    }

    //    DontDestroyOnLoad(gameObject);
    //}

    public void Pause()
    {
        UnlockCursor();
        Time.timeScale = 0;
        IsGameRunning = false;
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
