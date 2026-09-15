using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTag : MonoBehaviour
{
    private static int _tagCount;
    private int _myTag;

    private void Awake() => TakeTag();

    private void TakeTag()
    {
        
        if (_tagCount >= PracticeSetting.MaxTagCount)
        {
            _tagCount = PracticeSetting.MaxTagCount;
        }
        else
        {
            _myTag = _tagCount++;
        }
        Debug.Log($"CubeTag: MyTag는 {_myTag}, 지금까지 센 개수는 TagCount:{_tagCount}");
    }

    public static int GetTagCount()
    {
        return _tagCount;
    }

    public static void ResetTagCount()
    {
        _tagCount = 0;
        
        Debug.Log("개수를 되돌렸습니다.");
    }
}
