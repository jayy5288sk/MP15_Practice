using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameEffect : MonoBehaviour
{
    // 총이 발사되는 동안 유지가 되어야 함. 
    // 멈추는 순간 바로 꺼지면 안된다. 설정한 릴레이 후 자동으로 꺼지게 만들기.
    // gameObject.SetActive(false);

    [SerializeField] private float _deactivateTime;
    private float _time;

    private void OnEnable()
    {
        ResetTime();
    }

    private void Start()
    {
        gameObject.SetActive(_playStart);
    }

    private void Update()
    {
        UpdateTime();
        Deactivate();
    }

    public void Play()
    {
        // 딜레이 초기화
        ResetTime();
    }

    private void ResetTime()
    {
        _time = 0;
    }

    private void UpdateTime()
    {
        _time += Time.deltaTime;
    }

    private void Deactivate()
    {
        if (_time < _deactivateTime)
            return;

        if(_isDestroy)
            Destroy(gameObject);

        else
            gameObject.SetActive(false);
    }

    // 추가 처리
    [SerializeField] private bool _isDestroy;
    [SerializeField] private bool _playStart;

}
