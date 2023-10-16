using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NodeCanvas.BehaviourTrees;

namespace War
{
    [Serializable]
    public class SkillComponent : ISkillComponearnt
    {
        public Fighter owner;

        public BehaviourTreeOwner btOwner;

        //¶¯Ì¬¼ÓÔØ
        public BehaviourTree bt;

        private SkillContainer container = new SkillContainer();
        public SkillContainer Container { get => container; set => container = value; }

        public void Init(Fighter _owner)
        {
            this.owner = _owner;
            btOwner = owner.GetComponent<BehaviourTreeOwner>();
        }

        public void OnSkillFinish()
        {
            throw new NotImplementedException();
        }

        public void Play(int skillId)
        {
            //Container.Init(skillId);

            //Container.Next();


            btOwner.StartBehaviour(bt);
        } 
    }
}