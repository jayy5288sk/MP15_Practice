using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LayerMaskExtension
{
    public static bool Contains(this LayerMask mask, int layer)
    {
        return (mask.value & (1 << layer)) != 0;
    }

    public static bool Contains(this LayerMask mask, GameObject gameObj)
    {
        return (mask.value & (1 << gameObj.layer)) != 0;
    }

    public static bool Contains(this LayerMask mask, Component comp)
    {
        return (mask.value & (1<<comp.gameObject.layer)) != 0;
    }

    // or 연산자를 사용
    public static LayerMask Add(this LayerMask mask, int layer)
    {
        return (mask.value | (1 << layer));
    }

    public static LayerMask Add(this LayerMask mask, GameObject gameObj)
    {
        return (mask.value | (1 << gameObj.layer));
    }

    public static LayerMask Add(this LayerMask mask, Component comp)
    {
        return (mask.value | (1 << comp.gameObject.layer));
    }

    public static LayerMask Remove(this LayerMask mask, int layer)
    {
        return (mask.value & ~(1 << layer));
    }
    public static LayerMask Remove(this LayerMask mask, GameObject gameObj)
    {
        return (mask.value & ~(1 << gameObj.layer));
    }
    public static LayerMask Remove(this LayerMask mask, Component comp)
    {
        return (mask.value & ~(1 << comp.gameObject.layer));
    }

    public static LayerMask Everything(this LayerMask mask)
    {
        return ~0;
    }

    public static LayerMask Nothing(this LayerMask mask)
    {
        return 0;
    }
}
