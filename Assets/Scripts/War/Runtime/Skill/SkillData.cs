using Sirenix.OdinInspector;
using System;
namespace War
{
    [Serializable]
    public class SkillData
    {
        public int id = -1;

        public string name;

        [Title("ʩ����Χ")]
        public UseSkillRange useSkillRange;

        [Title("ʱ���¼��б�")]
        public SkillEventData[] eventData;
    }
}