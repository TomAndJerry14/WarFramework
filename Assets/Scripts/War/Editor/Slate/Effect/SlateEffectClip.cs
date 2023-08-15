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
    [Name("ÌØÐ§´æ»î")]
    [Attachable(typeof(SlateEffectTrack))]
    public class SlateEffectClip : SlateSkillClip
    {
        [SerializeField]
        [HideInInspector]
        private float _length = 1;
        public override float length { get => _length; set => _length = value; }

        public GameObject effect;

        private GameObject instantiateEffect;

        protected override void OnEnter()
        {
            base.OnEnter();

            if (instantiateEffect == null)
            {
                instantiateEffect = Instantiate(effect);
                instantiateEffect.transform.parent = role.transform;
                instantiateEffect.transform.localPosition = Vector3.zero;
            }
        }


        protected override void OnExit()
        {
            base.OnExit();

            DestroyImmediate(instantiateEffect);
        }
    }
}