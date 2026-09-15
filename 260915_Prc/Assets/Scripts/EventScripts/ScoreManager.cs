using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    private int _score;
    
    public static ScoreManager Instance { get; private set; }
    
    public Action<int> ScoreChanged;

    private void Awake() => SetSingleton();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddScore(10);
        }
    }

    public void AddScore(int amount)
    {
        _score += amount;
        
        if (ScoreChanged != null)
        {
            ScoreChanged?.Invoke(_score);
        }
        else
        {
            return;
        }
    }

    private void SetSingleton()
    {
        Instance = this;
    }
}
