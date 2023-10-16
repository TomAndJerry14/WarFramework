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
    [Attachable(typeof(SlateLineRenderTrack))]
    public class SlateLineRenderClip : ActionClip
    {
        [SerializeField]
        private float _length = 1;
        public override float length { get => _length; set => _length = value; }

        public Fighter role;

        public Vector3 target;

        private GameObject instantiate;

        protected override void OnEnter()
        {
            base.OnEnter();

            role = base.actor.GetComponent<Fighter>();
            if (!instantiate)
                instantiate = new GameObject();
            instantiate.AddComponent<LineRenderer>().SetPositions(new Vector3[]
            {
                this.actor.transform.position,
                target,
            });
        }


        protected override void OnExit()
        {
            base.OnExit();

            Destroy(instantiate);
        }
    }
}