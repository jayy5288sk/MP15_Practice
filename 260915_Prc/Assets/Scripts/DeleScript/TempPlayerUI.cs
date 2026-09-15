using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TempPlayerUI : MonoBehaviour
{
    public TempPlayer Player;
    [SerializeField] private TextMeshProUGUI _playerHpText;

    //private void Update()
    //{
    //    RefreshHealthUI(Player.playerHp);
    //}

    // 활성화 될 때.
    private void OnEnable()
    {
        Player.OnHealthChanged += RefreshHealthUI;
    }

    //private void Update()
    //{
    //    // 이벤트를 선언하지 않았다면 외부에서 이상하게 사용이 가능.
    //    Player.OnHealthChanged?.Invoke(Player.playerHp);
    //}

    private void OnDisable()
    {
        Player.OnHealthChanged -= RefreshHealthUI;
    }

    public void RefreshHealthUI(int health)
    {
        Debug.Log("UI 갱신");
        _playerHpText.text = health.ToString();
    }
}
