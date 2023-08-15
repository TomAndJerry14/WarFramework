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
    [Name("Buff³ÖÐø")]
    [Attachable(typeof(SlateBuffTrack))]
    public class SlateBuffClip : ActionClip
    {
        [SerializeField]
        [HideInInspector]
        private float _length = 1;
        public override float length { get => _length; set => _length = value; }

        public Fighter role;

        

        protected override void OnCreate()
        {
            Debug.Log("SlateBuffClip - OnCreate");
            base.OnCreate();

            Matrix4x4 mat;
            
        }

        protected override void OnEnter()
        {
            Debug.Log("SlateBuffClip - OnEnter");
            base.OnEnter();

            role = base.actor.GetComponent<Fighter>();

        }

        protected override void OnExit()
        {
            Debug.Log("SlateBuffClip - OnExit");
            base.OnExit();

        }
    }
}