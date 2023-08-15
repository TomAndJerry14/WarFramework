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
    [Name("½ÓÊÜÊäÈë")]
    [Attachable(typeof(SlateReceiveInputTrack))]
    public class SlateReceiveInputClip : ActionClip
    {
        [SerializeField]
        [HideInInspector]
        private float _length;
        public override float length { get => _length; set => _length = value; }

        public SlateReceiveInputEnum inputEnum;

        [ShowIf("inputEnum", Value = SlateReceiveInputEnum.KeyCode)]
        public KeyCode keycode;

        [ShowIf("inputEnum", Value = SlateReceiveInputEnum.MouseClick)]
        public Vector3 mousePosition;

        public Fighter role;

        protected override void OnEnter()
        {
            base.OnEnter();

            role = base.actor.GetComponent<Fighter>();
        }

    }
}