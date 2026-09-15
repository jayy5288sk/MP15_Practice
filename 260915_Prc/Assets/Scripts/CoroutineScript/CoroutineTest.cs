using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    //private float _elapsedTime;
    // private float _time = 2f;

    [SerializeField] private float _delay;
    private WaitForSeconds _wait;
    private Coroutine _routine;
    private bool isBool;

    private void Awake()
    {
        _wait = new WaitForSeconds(_delay);
    }

    private void Start()
    {
        Debug.Log("Start 시작");
        //StartCoroutine(MyRoutine());
        //StartCoroutine(MyRoutine());
        Debug.Log("Start 종료");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Run();

        if (Input.GetKeyDown(KeyCode.Alpha2))
            Stop();
    }

    private void Run()
    {
        if (_routine != null)
            return;

        StartCoroutine(MyRoutine());
    }

    private void Stop()
    {
        if (_routine == null)
            return;

        StopCoroutine(_routine);
        _routine = null;
    }

    private IEnumerator MyRoutine()
    {
        //Debug.Log("Coroutine 1");
        yield return _wait;
        Debug.Log("Coroutine");
        // 특정 조건이 충족될 때까지 기다리는 것.
        //while(true)
        //{
        //    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        //    Debug.Log("Coroutine");
        //}

        //Debug.Log("Coroutine 2");
        //yield return new WaitForSeconds(1f);
        //Debug.Log("Coroutine 3");
        //yield return new WaitForSeconds(1f);
        //Debug.Log("Coroutine 4");
        //yield return new WaitForSeconds(1f);

        //Debug.Log("Coroutine 5");

        //while(true)
        //{
        //    yield return new WaitForSeconds(0.1f);
        //    Debug.Log("Coroutine");
        //}
        //while (true)
        //{
        //    // _time초간 대기
        //    yield return new WaitForSeconds(_time);
        //    Debug.Log("지정시간 경과");
        //}
    }
    //private void Update()
    //{
    //    _elapsedTime += Time.deltaTime;

    //    if(_elapsedTime>=_time)
    //    {
    //        _elapsedTime = 0f;
    //        Debug.Log("지정시간 경과");
    //    }
    //}
}
