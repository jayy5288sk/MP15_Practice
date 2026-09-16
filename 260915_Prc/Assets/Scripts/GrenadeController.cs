using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeController : MonoBehaviour
{
    [SerializeField] private float _explosionDelay;
    [SerializeField] private float _range;
    [SerializeField] private int _damage;
    [SerializeField] private float _knockbackForce;
}
