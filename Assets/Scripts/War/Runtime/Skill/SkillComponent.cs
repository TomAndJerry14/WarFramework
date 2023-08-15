using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace War
{
    [Serializable]
    public class SkillComponent : ISkillComponearnt
    {
        private SkillContainer container = new SkillContainer();
        public SkillContainer Container { get => container; set => container = value; }

        public void OnSkillFinish()
        {
            throw new NotImplementedException();
        }

        public void Play(int skillId)
        {
            Container.Init(skillId);

            Container.Next();

           
        }
    }
}