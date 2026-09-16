using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerGrenadeUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _GrenadeCount;
    [SerializeField] private GameObject _grenadeUIControll;
    private PlayerWeapon _weapon;

    private void Awake() => CacheComponents();
    private void Update() => RefreshMegazineUI();

    public void RefreshMegazineUI()
    {
        if (!_weapon._isGrenade)
        {
            _grenadeUIControll.SetActive(false);
        }
        else
        {
            _grenadeUIControll.SetActive(true);
        }
        _GrenadeCount.text = $" 탄약: {_weapon.CurrentGrenadeCounts} / {_weapon.MaxGrenadeCounts}";
    }

    private void CacheComponents()
    {
        _weapon = GetComponentInChildren<PlayerWeapon>();
    }
}
