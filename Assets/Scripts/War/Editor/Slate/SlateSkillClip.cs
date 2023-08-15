using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slate;
using Slate.ActionClips;
using Sirenix.OdinInspector;
using ShowIf = Sirenix.OdinInspector.ShowIfAttribute;
using System;

namespace War
{
    public class SlateSkillClip : ActionClip
    {
        [HideInInspector]
        public Fighter role; 

        protected override void OnEnter()
        {
            base.OnEnter();

            role = base.actor.GetComponent<Fighter>();
        }

    }
}