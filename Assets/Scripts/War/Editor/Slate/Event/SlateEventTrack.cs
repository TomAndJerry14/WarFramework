using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slate;

namespace War
{
    [Name("����/�¼�")]
    [Attachable(typeof(ActorGroup))]
    public class SlateEventTrack : CutsceneTrack
    {
        public Fighter sender;

        protected override void OnEnter()
        {
            base.OnEnter();

            ((ActorGroup)parent).actor = sender.gameObject;
        }
    }
}