using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalLight : MonoBehaviour
{
    private Renderer _cubeRender;
    private readonly WaitForSeconds _waitOneSecond = new WaitForSeconds(1f);
    private Coroutine _signalRoutine;
    private bool _isCrossRequested = false;

    private void Awake()
    {
        _cubeRender = GetComponent<Renderer>();
    }

    //private void Start() => StartCoroutine(RunSignalRoutine());

    private void Update()
    {
        InputStart();
        CrossRequest();
    }

    private IEnumerator RunSignalRoutine()
    {
        //Debug.Log($"SignalLight: 1st Line, Record Time: {Time.time}");
        ////yield return null;
        //yield return new WaitForSeconds(1f);
        //Debug.Log($"SignalLight: 2nd Line, Record Time: {Time.time}");

        while (true)
        {
            Debug.Log($"SignalLight: 빨간불입니다. Record Time: {Time.time}");
            _cubeRender.material.color = new Color32(255, 50, 50, 1);
            yield return _waitOneSecond;
            
            Debug.Log($"SignalLight: 노란불입니다. Record Time: {Time.time}");
            _cubeRender.material.color = Color.yellow;
            //yield return _waitOneSecond;
            yield return new WaitUntil(() => _isCrossRequested);
            _isCrossRequested = false;
            
            Debug.Log($"SignalLight: 초록불입니다. Record Time: {Time.time}");
            _cubeRender.material.color = new Color32(0, 255, 150, 1);
            yield return _waitOneSecond;
        }
    }

    private void InputStart()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(_signalRoutine == null)
            { 
                StartRoutine(); 
            }

            else
            {
                StopRoutine();
                return;
            }
        }
    }

    private void StartRoutine()
    {
        _signalRoutine = StartCoroutine(RunSignalRoutine());
    }

    private void StopRoutine()
    {
        StopCoroutine(_signalRoutine);
        _signalRoutine = null;
    }

    private void CrossRequest()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            _isCrossRequested = true;
        }
    }
}
