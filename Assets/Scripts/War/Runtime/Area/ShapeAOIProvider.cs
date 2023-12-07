using System;
using System.Collections.Generic;
using UnityEngine;
using War;

public class ShapeAOIProvider : IAOITargetProvider
{
    AreaData areaData;
    public ShapeAOIProvider(AreaData areaData)
    {
        this.areaData = areaData;
    }
    public Fighter[] GetAOITarger(Vector2 pos)
    {
        Fighter[] fighters = WarScene.Instance.GetAllFighter();
        var results = new List<Fighter>();
        switch (areaData.shape)
        {
            case Shape.Circle:
                for (int i = 0; i < fighters.Length; i++)
                {
                    Vector3 fighterPos = fighters[i].transform.position;
                    if (Vector2.Distance(areaData.circle.center + pos, new Vector2(fighterPos.x, fighterPos.z)) <= areaData.circle.range)
                    {
                        results.Add(fighters[i]);
                    }
                }

                break;
            case Shape.Box:
                throw new NotImplementedException("TODO");
                break;
            case Shape.ConvexPolygon:
                throw new NotImplementedException("TODO");
                break;
        }
        return results.ToArray();
    }
}
