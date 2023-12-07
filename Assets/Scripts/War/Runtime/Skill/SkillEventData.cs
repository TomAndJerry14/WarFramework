#if UNITY_EDITOR
using Sirenix.OdinInspector;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
/// <summary>
/// TODO
/// 子弹还是必要的，不能和AOE混在一起，子弹可以被一些位移技能穿梭
/// </summary>
namespace War
{
    [Serializable]
    public class SkillEventData
    {
#if UNITY_EDITOR
        [Title("------------事件------------")]
#endif      
        /// <summary>
        /// 面向敌人
        /// </summary>
        public bool faceToEnemy;

        public float time;

        public EventType eventType;

#if UNITY_EDITOR
        [ShowIf("eventType", Value = EventType.AOEPropertyChange)]
#endif
        public EffectEnum effectEnum;

#if UNITY_EDITOR
        [ShowIf("eventType", Value = EventType.AOEPropertyChange)]
#endif
        public AreaData areaData;

//#if UNITY_EDITOR
//        [ShowIf("eventType", Value = EventType.Effect)]
//        [ShowIf("eventType", Value = EventType.Bullet)]
//#endif
        public float survivalTime;


//#if UNITY_EDITOR
//        [ShowIf("eventType", Value = EventType.Effect)]
//        [ShowIf("eventType", Value = EventType.Bullet)]
//#endif
        public string gameObjectPath;

#if UNITY_EDITOR
        [ShowIf("eventType", Value = EventType.Bullet)]
#endif
        public Vector3 offset;

        public float value;
    }
}
