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
    [Name("接受输入")]
    [Attachable(typeof(SlateReceiveInputTrack))]
    public class SlateReceiveInputClip : SlateSkillClip
    {
        [SerializeField]
        [HideInInspector]
        private float _length = 1;
        public override float length { get => _length; set => _length = value; }

        private ReceiveInputResult result;

        public KeyCode[] keyCodes;

        private float timeSinceEnter;

        protected override void OnEnter()
        {
            base.OnEnter();

            timeSinceEnter = Time.realtimeSinceStartup;
            role = base.actor.GetComponent<Fighter>();
        }

        protected override void OnUpdate(float time)
        {
            base.OnUpdate(time);

            foreach (var item in InputManager.Instance.GetQueue())
            {
                throw new Exception("todo 按键判断");
            }
        }

        public override IResult GetResult()
        {
            return result;
        }
    }
}