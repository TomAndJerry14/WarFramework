using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slate;

namespace War
{
    [Name("技能/判定及伤害")]
    [Attachable(typeof(ActorGroup))]
    public class SlateSkillTrack : CutsceneTrack
    {
        public Fighter sender;

        //todo 添加接受技能轨道 ， 接受技能与释放技能分开为两个不同的技能
        protected override void OnEnter()
        {
            base.OnEnter();

            sender = ((ActorGroup)parent).actor.GetComponent<Fighter>();
        }
    }
}