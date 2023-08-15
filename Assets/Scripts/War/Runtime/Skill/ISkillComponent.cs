using System.Collections.Generic;

namespace War
{
    public interface ISkillComponearnt
    {
        SkillContainer Container { get; }

        void Play(int skillId = -1);

        void OnSkillFinish();
    }
}