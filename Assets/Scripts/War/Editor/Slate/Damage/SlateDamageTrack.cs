using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slate;

namespace War
{
    [Name("����/�ж����˺�")]
    [Attachable(typeof(ActorGroup))]
    public class SlateDamageTrack : SlateSkillTrack
    {
        protected override void OnCreate()
        {
            base.OnCreate();

            Debug.Log("SlateDamageTrack - OnCreate");
        }

        protected override void OnEnter()
        {
            base.OnEnter();

            Debug.Log("SlateDamageTrack - OnEnter");
        }
    }
}