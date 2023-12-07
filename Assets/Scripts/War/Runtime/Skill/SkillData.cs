using Sirenix.OdinInspector;
using System;
namespace War
{
    [Serializable]
    public class SkillData
    {
        public int id = -1;

        public string name;

        [Title("施法范围")]
        public UseSkillRange useSkillRange;

        [Title("时间事件列表")]
        public SkillEventData[] eventData;
    }
}