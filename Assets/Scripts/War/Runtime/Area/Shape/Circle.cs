using System;
using UnityEngine;

[Serializable]
public struct Circle : IShape
{
    public Vector2 center;
    public float range;

    public bool InArea(Vector2 worldPos)
    {
        return (center - worldPos).magnitude <= range * 2;
    } 
}
