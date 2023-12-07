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



    [Name("´´½¨×Óµ¯")]
    [Attachable(typeof(SlateEntityTrack))]
    public class SlateBubbleEntityClip : SlateSkillClip
    {
        [SerializeField]
        private float _length = 1;
        public override float length { get => _length; set => _length = value; }

        public Bullet go;
        private GameObject instantiate;

        private HitResult result;


        protected override void OnEnter()
        {
            base.OnEnter();

            role = base.actor.GetComponent<Fighter>();

            if (!instantiate)
                instantiate = GameObject.Instantiate(go.gameObject);
            instantiate.GetComponent<Bullet>().onHit += OnHit;
        }


        protected override void OnExit()
        {
            base.OnExit();
            instantiate.GetComponent<Bullet>().onHit -= OnHit;
            Destroy(instantiate);
        }


        public void OnHit(HitResult result)
        {
            this.result = result;
        }

        public override IResult GetResult()
        {
            return this.result;
        }
    }
}