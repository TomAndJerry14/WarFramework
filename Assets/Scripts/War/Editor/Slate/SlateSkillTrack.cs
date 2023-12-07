using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Slate;

namespace War
{
    [Name("����/�ж����˺�")]
    [Attachable(typeof(ActorGroup))]
    public class SlateSkillTrack : CutsceneTrack
    {
        public Fighter _sender;

        //todo ��ӽ��ܼ��ܹ�� �� ���ܼ������ͷż��ֿܷ�Ϊ������ͬ�ļ���
        protected override void OnEnter()
        {
            base.OnEnter();

            _sender = ((ActorGroup)parent).actor.GetComponent<Fighter>();
        }
    }
}