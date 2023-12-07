using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slate;

namespace War
{
    [Name("����/��������")]
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