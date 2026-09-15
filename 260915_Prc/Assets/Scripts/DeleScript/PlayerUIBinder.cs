using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIBinder : MonoBehaviour
{
    private TempPlayer _player;
    [SerializeField] private TempPlayerUI _playerUI;
    [SerializeField] private HealthGauge _healthGuage;
    [SerializeField] private ExpGauge _expGuage;

    private void Awake() => CacheComponents();

    private void OnEnable() => BindPlayerStatusChangeEvents();
    private void OnDisable() => UnbindPlayerStatusChangeEvents();
    
    private void BindPlayerStatusChangeEvents()
    {
        _player.OnHealthChanged += _playerUI.RefreshHealthUI;
        _player.OnHealthChanged += _healthGuage.RefreshGuage;

        _player.Exp.AddListener(_expGuage.RefeshGauge);
    }

    private void UnbindPlayerStatusChangeEvents()
    {
        _player.OnHealthChanged -= _playerUI.RefreshHealthUI;
        _player.OnHealthChanged -= _healthGuage.RefreshGuage;

        _player.Exp.AddListener(_expGuage.RefeshGauge);
    }
    private void CacheComponents()
    {
        _player = GetComponent<TempPlayer>();
    }
}
