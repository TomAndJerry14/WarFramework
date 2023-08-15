using System;
using UnityEngine;

/// <summary>
/// Í¹¶à±ßÐÎ
/// </summary>
[Serializable]
public struct ConvexPolygon : IShape
{
    public Vector2[] points;

    public bool InArea(Vector2 worldPos)
    {
        var len = points.Length;
        int? side = null;
        for (int i = 0; i < len; i++)
        {
            Vector2 lastPoint = points[(len - 1 + i) % len];
            Vector2 point = points[i];

            Debug.Log(lastPoint);
            Vector2 A = worldPos - lastPoint;
            Vector2 B = point - worldPos;
            Vector3 cross = Vector3.Cross(A, B);
            if (side != null && side != cross.z)
                return false;

            side = cross.z > 0 ? 1 : 0;
        }

        return true;
    }
}
