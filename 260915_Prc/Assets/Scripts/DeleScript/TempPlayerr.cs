using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// + 
using System;
// ++
using UnityEngine.Events;

public class TempPlayerr : MonoBehaviour
{
    private void Start()
    {
        MyClass c1 = new();
        c1.value = 5;
        MyClass c2 = c1;
        c2.value = 15;
        Debug.Log($"C1 {c1.value}, C2 {c2.value}");

        string s1 = "sadsad";
        string s2 = s1;
        s2 = "gggggg";
        Debug.Log($"s1 : {s1}, s2 : {s2}");
    }
}

public class MyClass
{
    public int value;
}
