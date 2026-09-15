using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltShooter : MonoBehaviour
{
    //[SerializeField] private BoltPool _boltPool;
    [SerializeField] private Transform _muzzlePoint;

    private void Update()
    {
        SpawnBolt();
    }

    private void SpawnBolt()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bolt = BoltPool.Instance.Take();
    
            if(bolt == null)
                return;
            
            bolt.transform.position = _muzzlePoint.position;
            
            Bolt boltPrefab = bolt.GetComponent<Bolt>();
            
            if (boltPrefab != null)
            {
                boltPrefab.ResetState(_muzzlePoint.position);
            }
        }
    }
}
