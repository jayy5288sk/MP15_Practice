using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletControll : MonoBehaviour, IPoolable
{
    private int _damage;
    private float _speed;

    private void OnTriggerEnter(Collider other)
    {
        // 플레이어인 경우 데미지 추가 
        if(other.CompareTag("player"))
        {
            // TODO : 데미지 추가
            //Debug.Log("player shots.");
        }

        // 벽인 경우엔 파괴
        // Destroy(gameObject);
        // + 
        Pool.Return(this);
    }

    // Spawn 기준 제한시간 이후 파괴 예약.

    // if 어딘가에 부딪혔을 때
    // 플레이어인 경우 데미지 발생.
    // 벽인 경우에는 파괴

    private void Update()
    {
        MoveForward();
        // +
        UpdateElapsedTime();
        ReturnToPool();
    }

    // 앞으로의 운동
    private void MoveForward()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    // 터렛으로부터 데이터를 전달받아 총알의 속도, 파괴 시간을 입력받도록 만들자. 
    public void SetData(int damage, float speed, float returnDelay)
    {
        _damage = damage;
        _speed = speed;

        //Destroy(gameObject, destroyDelay);
        _returnDelay = returnDelay;
        //_elapsedTime = 0f;
    }

    // +
    public ObjectPool Pool { get; set; }
    public Transform tr { get => transform; }

    private float _returnDelay;
    private float _elapsedTime;
    public void ReturnToPool()
    {
        // 1. 제한시간 경과 필요
        if (_elapsedTime >= _returnDelay) 
        {
            // 2. 어느 OPool에 들어가는지에 대한 참조 필요 => 이젠 있음. 자신을 넣어줄 것.
            // pool 내부적으로 다시 오브젝트를 넣어놓는 기능 필요.
            _elapsedTime = 0; // 시간 초기화

            Pool.Return(this);
        }
    }

    private void UpdateElapsedTime()
    {
        _elapsedTime += Time.deltaTime;
    }
}