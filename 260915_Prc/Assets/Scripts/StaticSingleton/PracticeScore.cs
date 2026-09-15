using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeScore : MonoBehaviour
{
    private int _point;
    public static PracticeScore Instance { get; private set; }

    public int Point => _point;

    private void Awake()
    {
        SetSingleton();
    }

    private void SetSingleton()
    {
        // 중복 판별
        if (Instance != null && Instance != this) 
        {
            Destroy(gameObject);
        }
        else
        {
            // Instance에 자기 자신을 담고  
            Instance = this;
            // DontDestroyOnLoad로 씬 전환에서 지켜 냅니다.  
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddPoint(int point)
    {
        _point += point;
        Debug.Log($"PracticeScore: 점수가 {_point}가 되었습니다.");
    }
}
