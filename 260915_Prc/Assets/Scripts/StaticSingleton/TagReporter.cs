using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagReporter : MonoBehaviour
{
    private void Start()
    {
        ReportCount();
    }

    private void Update()
    {
        CallReset();
    }

    private void ReportCount()
    {
        CubeTag.GetTagCount();
    }

    private void CallReset()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            CubeTag.ResetTagCount();
        }
    }
}
