using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private int _score;

    private void Start()
    {
        UpdateText();
    }

    public void AddScore()
    {
        // _score를 10 늘리고 UpdateText를 부릅니다.  
        _score += 10;
        UpdateText();
    }

    private void UpdateText()
    {
        // _scoreText의 text에 "Score: " 와 _score를 이어 붙여 넣습니다.  
        _scoreText.text = "Score: " + $"{_score}";
    }
}
