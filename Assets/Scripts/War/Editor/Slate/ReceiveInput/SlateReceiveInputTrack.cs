using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slate;

namespace War
{
    [Name("技能/接受输入")]
    [Attachable(typeof(ActorGroup))]
    public class SlateReceiveInputTrack : SlateSkillTrack
    {
        protected void OnEnter()
        {
            base.OnEnter();

            ((ActorGroup)base.parent).actor = _sender.gameObject;
        }
    }
}