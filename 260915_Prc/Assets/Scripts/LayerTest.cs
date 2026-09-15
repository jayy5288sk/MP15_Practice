using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerTest : MonoBehaviour
{
    public LayerMask TargetLayer;
    [SerializeField] private float _rayDistance;

    private void Start()
    {
        TargetLayer = TargetLayer.Add(8);
    }

    // 뭔가 연산을 했을 때 0이 아닐 때 -> And 결과가 != 0; 
    private void OnTriggerEnter(Collider other)
    {
        //// 자릿수
        ////Debug.Log(other.gameObject.layer);
        //int layer = (1 << other.gameObject.layer);
        ////Debug.Log(layer);
        ////if(layer == TargetLayer.value)
        //if ((TargetLayer.value & layer) != 0) 
        //{
        //    Debug.Log("찾음");
        //}
        ////Debug.Log(TargetLayer.value);
        //

        // 이렇게 하려면 확장 기능으로 추가해야 한다.
        // 자주 쓰이는 로직을 확장 메서드를 통해서 제공될 수 있도록 한다.
        if (TargetLayer.Contains(other))  
        {
            Debug.Log("찾음");
        }
    }



    public void Update()
    {
        //// 이 오브젝트의 위치에서 정면으로 발사되는 Ray 생성. 
        //Ray ray = new Ray(transform.position, transform.forward);
        //// Raycast를 사용
        //RaycastHit hit;

        //// Raycast를 사용하여 감지된 gameObject의 이름 출력
        //// Raycast의 거리는 인스펙터에서 조절할 수 있도록 한다.
        //// 원하는 Layer만 감지할 수 있다. 
        //if (Physics.Raycast(ray, out hit, _rayDistance, TargetLayer))
        //{
        //    Debug.Log($"{hit.transform.name} 감지");
        //}
    }

    // 기능 선언
    private bool ContainsLayer(LayerMask mask, Collider layer)
    {
        return 0 != (mask.value & (1 << layer.gameObject.layer));
    }
}
