using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GrenadeThrow : MonoBehaviour
{
    [SerializeField] private Image _gauge;
    private PlayerWeapon _grenade;
    [SerializeField] private GameObject _UIContainer;
    private void Awake() => CacheComponents();

    private void Start()
    {
        _UIContainer.SetActive(false);
    }
    private void Update()
    {  
        InitGuage();
    }

    private void RefreshGauge()
    {
        _gauge.fillAmount = _grenade.CurrentGrenadeThrowForce / (float)_grenade.MaxGrenadeThrowForce;
    }

    private void InitGuage()
    {
        if (_grenade.GetPressThrowKey)
        {
            _UIContainer.SetActive(true);
            RefreshGauge();  
        }

        if (_grenade.GetReleaseThrowKey)
        {
            _UIContainer.SetActive(false);
        }
    }
    
    private void CacheComponents()
    {
        _grenade = GetComponent<PlayerWeapon>();
    }
}
