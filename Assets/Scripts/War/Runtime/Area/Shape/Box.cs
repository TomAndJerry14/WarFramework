
using System;
using UnityEngine;

[Serializable]
public struct Box
{
    public float length;
    public float width;

    public bool InArea(Vector2 worldPos)
    {
        throw new System.Exception("尚未实现");
    }
}