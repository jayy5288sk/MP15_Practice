using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoltPool : MonoBehaviour
{
    [SerializeField] private GameObject _boltPrefab;
    [SerializeField] private int _poolSize = 8;

    private GameObject[] _bolts;
    private int _count;

    public static BoltPool Instance { get; private set; }

    private void Awake()
    {
        SetSingleton();
    }

    private void Start()
    {
        FillPool();
    }

    private void SetSingleton()
    {
        // 앞서 싱글톤 패턴 주제에서 다룬 형태 그대로입니다.  
        // 다만 DontDestroyOnLoad는 붙이지 않습니다.  
        // 중복 판별
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            // Instance에 자기 자신을 담고  
            Instance = this;
            //// DontDestroyOnLoad로 씬 전환에서 지켜 냅니다.  
            //DontDestroyOnLoad(gameObject);
        }
    }

    private void FillPool()
    {
        // _poolSize 크기의 배열을 만들고  
        _bolts = new GameObject[_poolSize];
        // 그 수만큼 Instantiate해서 곧바로 끈 뒤 앞자리부터 채웁니다.  
        for(int i =0; i < _bolts.Length; i++) 
        { 
            GameObject gameObj = Instantiate(_boltPrefab);
            gameObj.SetActive(false);
            _bolts[i] = gameObj;
        }
        // 다 채우면 _count를 _poolSize로 둡니다.  
        _count = _poolSize;
    }

    public GameObject Take()
    {
        if(_count > 0)
        {
            _count--;
            GameObject targetObject = _bolts[_count];
            _bolts[_count] = null;
            targetObject.SetActive(true);
    
            return targetObject;
        }
        
        return null;
    }
    
    public void Return(GameObject bolt)
    {
        if(_count < _poolSize)
        {
            bolt.SetActive(false);
            _bolts[_count] = bolt;
            _count++;
        }
    }
}
