using System;
using UnityEngine;

[Serializable]
public class Property
{
    [SerializeField]
    private float hp;
    public float Hp => hp;
}