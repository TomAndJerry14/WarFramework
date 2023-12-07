#if UNITY_EDITOR
using Sirenix.OdinInspector;
#endif
using System;

namespace War
{
    /// <summary>
    /// 施法范围
    /// </summary>
    [Serializable]
    public class UseSkillRange
    {
        public float range;

//        public UseSkillEnum useSkillEnum;

//#if UNITY_EDITOR
//        [ShowIf("useSkillEnum", Value = UseSkillEnum.AOE)]
//#endif
        public AreaData areaData;

//#if UNITY_EDITOR
//        [ShowIf("useSkillEnum", Value = UseSkillEnum.Bullet)]
//#endif

    }
}
