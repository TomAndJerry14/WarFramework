using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace War
{
    [Serializable]
    public class AreaData
    {
        IAOITargetProvider provider;

        //public AreaEnum areaEnum = AreaEnum.Area;

        public AreaEnum area = AreaEnum.Area;
        public bool ShapeToggle
        {
            get
            {
                return area == AreaEnum.Area;
            }
        }
        [ShowIfGroup("ShapeToggle")]
        [BoxGroup("ShapeToggle/Shape")]
        public Shape shape;

        [BoxGroup("ShapeToggle/Shape")]
        [ShowIf("shape", Value = Shape.Circle)]
        public Circle circle;

        [BoxGroup("ShapeToggle/Shape")]
        [ShowIf("shape", Value = Shape.ConvexPolygon)]
        public ConvexPolygon polygon;

        public void Init()
        {
            switch (area)
            {
                case AreaEnum.single:
                    break;
                case AreaEnum.Area:
                    provider = new ShapeAOIProvider();
                    break;
                case AreaEnum.link:
                    break;
                default:
                    break;
            }

        }

        public Fighter[] GetAOITarger(Vector3 sender)
        {
            return provider.GetAOITarger();
        }
    }
}
