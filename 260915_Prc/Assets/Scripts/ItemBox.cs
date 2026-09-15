using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemBox : MonoBehaviour, IInteractable
{
    public GameObject GameObject { get => gameObject; }
    public void Interact(IInteractor owner)
    {
        // owner의 능력치 상승
        // 인벤토리로 들어간다.
        // 무기가 생긴다거나
        // 장탄수를 늘리던가

        if (!(owner is PlayerController))
            return;

        PlayerController player = (PlayerController)owner;

        // public으로 이동 속도 변화를 줄 수 있는 함수를 주거나
        // 객체로 만들어 붙어있는 동안 변화시켜주고 Destroy나 Disable 때 원래대로 돌려주거나.

        // 상호작용을 위해 매개변수를 받고 그 상자는 파괴
        Destroy(gameObject);
    }

    private Outline _outline;
    private void Awake()
    {
        CacheComponents();
    }
    private void Start()
    {
        Init();
    }

    public void Targeting()
    {
        _outline.enabled = true;
    }

    public void Untargeting()
    {
        _outline.enabled = false;
    }

    private void CacheComponents()
    {
        _outline = gameObject.GetComponent<Outline>();
    }

    private void Init()
    {
        _outline.enabled = false;
    }
}
