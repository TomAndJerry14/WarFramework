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



    [Name("»­Ïß")]
    [Attachable(typeof(SlateEventTrack))]
    public class SlateEventClip : ActionClip
    {
        public override float length { get => 0; }

        public Fighter role;

        public SlateEventEnum Event;

        public string[] EventArgs;

        protected override void OnEnter()
        {
            base.OnEnter();

            role = base.actor.GetComponent<Fighter>();
        }

    }
}