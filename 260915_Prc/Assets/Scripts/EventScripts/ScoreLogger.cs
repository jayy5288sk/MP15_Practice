using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreLogger : MonoBehaviour
{
    private void Start()
    {
        BindScoreEvents();
    }

    private void BindScoreEvents()
    {
        ScoreManager.Instance.ScoreChanged += OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        Debug.Log($"ScoreLogger: Score is {score}");
    }
}
