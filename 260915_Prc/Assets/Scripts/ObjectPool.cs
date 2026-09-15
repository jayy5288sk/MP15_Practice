using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;

    //public void Resize()
    //{
    //    _pool = new IPoolable[newSize];
    //    // 기존 데이터 넣기
    //}

    [field: SerializeField] public int Size { get; private set; } // 크기
    private IPoolable[] _pool;
    public int Count { get; private set; } // 실질적으로 들어가있는 수
    public bool IsEmpty => Count == 0; // 코드 가독성 용도.

    private void Awake() => Init();
    
    // 배열에 꽉 차게끔 준비가 되었는데 
    private void Init()
    {
        _pool = new IPoolable[Size];

        for (int i = 0; i < _pool.Length; i++)
        {
            //IPoolable poolable = 
            //    Instantiate(_prefab, transform.position, transform.rotation)
            //    .GetComponent<IPoolable>();

            //_pool[i] = 
            //    Instantiate(_prefab, transform.position, transform.rotation)
            //    .GetComponent<IPoolable>();
            GameObject gameObj = Instantiate(_prefab);
            _pool[i] = gameObj.GetComponent<IPoolable>();
            _pool[i].Pool = this; // 자기 자신을 참조 걸어두기
            gameObj.SetActive(false);
        }

        Count = Size;
    }

    // 외부에서 사용 편하도록 하기
    // 반환형을 void에서 IPoolable로 변경
    public IPoolable Take()
    {
        //if(Count == 0)
        //    return null;
        if(IsEmpty)
            return null;

        Count--;
        IPoolable poolable = _pool[Count];
        _pool[Count] = null;

        return poolable;

        // 이것만 있으면 위험성 존재. 따라서 위 코드들로 진행.
        // return _pool[Count - 1]; 
    }
    
    // 다시 넣어주는 기능 추가
    public void Return(IPoolable poolable)
    {
        // 꽉 찼을 때 아무것도 하지 말아야 함.
        if (Size <= Count)
            return;

        poolable.tr.gameObject.SetActive(false);
        _pool[Count] = poolable;
        Count++;
    }
}