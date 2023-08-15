using System;
using UnityEngine;

[Serializable]
public struct Circle : IShape
{
    public Vector2 point;
    public float range;

    public bool InArea(Vector2 worldPos)
    {
        return (point - worldPos).magnitude <= range * 2;
    } 
}
