using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class PlayerExitControll : MonoBehaviour
{
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _exitButton;

    //private bool _isGameRunning = true;

    private void Start() => Init();
    private void OnEnable() => BindButtonEvent();

    private void OnDisable() => UnbindButtonEvent();

    private void Update()
    {
        Pause();
    }

    private void BindButtonEvent()
    {
        _continueButton.onClick.AddListener(LoadMainScreen);
        _continueButton.onClick.AddListener(ContinueScreen);
    }

    private void UnbindButtonEvent()
    {
        _continueButton.onClick.RemoveListener(LoadMainScreen);
        _continueButton.onClick.RemoveListener(ContinueScreen);
    }

    private void LoadMainScreen()
    {
        SceneManager.LoadScene(0);
    }

    private void ContinueScreen()
    {
        gameObject.SetActive(false);
        Run();
    }

    private void Run()
    {
        LockCursor();
        Time.timeScale = 1.0f;
        //_isGameRunning = true;
    }

    public void Pause()
    {
        gameObject.SetActive(true);
        UnlockCursor();
        Time.timeScale = 0;
        //_isGameRunning = false;
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

    private void Init()
    {
        //_isGameRunning = true;
        gameObject.SetActive(false);
        LockCursor(); 
        Time.timeScale = 1.0f;
    }
}
