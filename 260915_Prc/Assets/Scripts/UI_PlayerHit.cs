using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerHit : MonoBehaviour
{
    [SerializeField] private Image _hitByEnemyImage;
    [SerializeField] private float _blinkTime;
    private float _currentTime;
    private PlayerStatus _playerStatus;

    private bool _isStopPlayingImage => _currentTime >= _blinkTime;

    private void Awake() => CacheComponents();

    private void CacheComponents()
    {
        _playerStatus = GetComponentInChildren<PlayerStatus>();
    }

    private void Update()
    {
        Activate();
    }

    private void Activate()
    {
        UpdateTime();

        _hitByEnemyImage.color = Color.red;
    }

    private void Deactivate()
    {
        _hitByEnemyImage.color = Color.white;
    }

    private void UpdateTime()
    {
        _currentTime += Time.deltaTime;
    }
}
