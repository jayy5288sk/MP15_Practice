using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    [SerializeField] private float _meterPerSecond = 8f;
    [SerializeField] private float _lifeSeconds = 8f;

    private float _elapsed;

    private void Update()
    {
        MoveForward();
        CountLifeTime();
    }

    private void MoveForward()
    {
        // 앞서 Transform 주제에서 다룬 형태로 앞으로 나아갑니다.
        transform.Translate(Vector3.forward * _meterPerSecond * Time.deltaTime); 
    }

    private void CountLifeTime()
    {
        // _elapsed에 Time.deltaTime을 더하고  
        _elapsed += Time.deltaTime;
        
        // _lifeSeconds를 넘었으면 BoltPool.Instance의 Return을 부릅니다.  
        if(_elapsed >= _lifeSeconds)
        {
            BoltPool.Instance.Return(gameObject);
        }
    }

    public void ResetState(Vector3 pos)
    {
        transform.position = pos;
        _elapsed = 0f;
    }
}
