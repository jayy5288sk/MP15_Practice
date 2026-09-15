using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_HpAmount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _enemyHp;
    [SerializeField] private Image _gauge;
    private Monster _monster;

    private void Awake() => CacheComponents();
    private void Update()
    {
        RefreshMonsterHp();
    }
    private void RefreshMonsterHp()
    {
        _enemyHp.text = $"{_monster.CurrentHp} / {_monster.MaxHp}";
        _gauge.fillAmount = _monster.CurrentHp / (float)_monster.MaxHp;
    }

    private void CacheComponents()
    {
        _monster = GetComponentInChildren<Monster>();
    }
}
