using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _magazine;
    private PlayerWeapon _weapon;

    private void Awake() => CacheComponents();
    private void Update() => RefreshMegazineUI();

    public void RefreshMegazineUI()
    {
        _magazine.text = $" 탄약: {_weapon.CurrentMagazine} / {_weapon.MaxMagazine}";
    }

    private void CacheComponents()
    {
        _weapon = GetComponentInChildren<PlayerWeapon>();
    }
}
