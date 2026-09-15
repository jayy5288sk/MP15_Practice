using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlainShooter : MonoBehaviour
{
    [SerializeField] private GameObject _boltPrefab;

    private void Update()
    {
        ReadFireKey();
    }

    private void ReadFireKey()
    {
        // 스페이스 키를 누르면 Instantiate로 _boltPrefab을 하나 만듭니다.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_boltPrefab);
        }
    }
}
