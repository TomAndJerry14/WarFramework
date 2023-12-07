using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace War
{
    public static class SkillFactroy
    {
        public static SkillBase CreateSkill(int skillId, Fighter sender, Vector2 input, Fighter[] receivers = null)
        {
            var skill = new SkillBase();
            var data = Resources.Load<SkillSerializedObject>("SkillData/" + skillId.ToString()).skillData;
            skill.Init(data, sender, input, receivers);
            return skill;
        }
    }
}
