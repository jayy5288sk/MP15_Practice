using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointGiver : MonoBehaviour
{
    private const int POINT_PER_PRESS = 10;

    private void Start()
    {
        ReportPoint();
    }

    private void Update()
    {
        ReadPointKey();
    }

    private void ReportPoint()
    {
        // PracticeScore.Instance에서 지금 점수를 읽어 Console에 찍습니다.  
        Debug.Log($"현재 점수: {PracticeScore.Instance.Point}");
    }

    private void ReadPointKey()
    {
        // P 키를 누르면 PracticeScore.Instance의 AddPoint를 부릅니다.  
        if (Input.GetKeyDown(KeyCode.P))
        {
            PracticeScore.Instance.AddPoint(POINT_PER_PRESS);
        }
    }
}
