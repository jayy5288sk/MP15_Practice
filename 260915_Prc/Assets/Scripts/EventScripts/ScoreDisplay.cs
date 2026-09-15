using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
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
        Debug.Log($"ScoreDisplay: Score is {score}");
    }
}
