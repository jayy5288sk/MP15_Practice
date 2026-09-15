using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
// + 
using System;
// ++
using UnityEngine.Events;

public class TempPlayer : MonoBehaviour
{
    //public delegate void IntChange(int value);

    //public int playerHp { get; private set; }
    private int _health;
    public int playerHp
    {
        get => _health;

        private set
        {
            _health = value;
            OnHealthChanged?.Invoke(playerHp);
        }
    }
    //public TempPlayerUI UI;
    // 체력이 바뀌었을 때란 직관적인 이름을 암묵적으로 사용한다.
    //public event IntChange OnHealthChanged;
    public event Action<int> OnHealthChanged;

    public ObsevableProperty<float> Exp = new(0);

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TakeDamage(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Heal(10);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            Exp.Value += 20.5f;
        }
    }

    public void TakeDamage(int damage)
    {
        playerHp -= damage;
        Debug.Log($"{damage} 받음");
        //UI.RefreshHealthUI(playerHp);
    }

    public void Heal(int heal)
    {
        playerHp += heal;
        Debug.Log($"{heal}만큼 회복");
        //UI.RefreshHealthUI(playerHp);
    }

    //private void Awake() => Init();

    //private void Init()
    //{
    //    Exp = new ObsevableProperty<float>(0);
    //}

    private void OnDestroy() => Exp.RemoveAllListeners();

    // ++
    public UnityEvent TempEvent; // 인스펙터에서 버튼과 동일하게 뜨게 된다.

    private void OnEnable()
    {
    }

    //private void TryLoadData(Action s, Action b)
    //{
    //    // 성공한 것에 대한 함수
    //    if(성공)
    //    {
    //        s.Invoke();
    //    }
    //    // 실패한 것에 대한 함수
    //    else
    //    {
    //        b.Invoke();
    //    }
    //}
}
