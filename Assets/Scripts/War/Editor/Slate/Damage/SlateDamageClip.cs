using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slate;
using Slate.ActionClips;
using Sirenix.OdinInspector;
using ShowIf = Sirenix.OdinInspector.ShowIfAttribute;

namespace War
{
    [Name("ÉËº¦ÅÐ¶¨")]
    [Attachable(typeof(SlateDamageTrack))]
    public class SlateDamageClip : ActionClip
    {
        public AreaData data_area;

        public float damage = 0;

        public override float length { get => 0; }


        public Fighter sender;


        public bool ShowReceiveToogle
        {
            get
            {
                return data_area.area == AreaEnum.link || data_area.area == AreaEnum.single;
            }
        }
        [ShowIfGroup("ShowReceiveToogle")]
        public Fighter Receive;

        protected override void OnCreate()
        {
            Debug.Log("SlateDamageClip - OnCreate");
            base.OnCreate();
        }

        protected override void OnEnter()
        {
            Debug.Log("SlateDamageClip - OnEnter");
            base.OnEnter();

            sender = ((SlateDamageTrack)parent).sender;
            Debug.Log(sender.name);
        }

        protected override void OnExit()
        {
            Debug.Log("SlateDamageClip - OnExit");
            base.OnExit();
        }
    }
}