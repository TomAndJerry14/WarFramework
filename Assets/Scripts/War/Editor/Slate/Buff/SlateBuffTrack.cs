using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slate;

namespace War
{
    [Name("¼¼ÄÜ/Ìí¼ÓBuff")]
    [Attachable(typeof(ActorGroup))]
    public class SlateBuffTrack : SlateSkillTrack
    {
        protected override void OnCreate()
        {
            base.OnCreate();

            Debug.Log("SlateBuffTrack - OnCreate");
        }

        protected override void OnEnter()
        {
            base.OnEnter();

            Debug.Log("SlateBuffTrack - OnEnter");
        }
    }
}