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
        public Fighter sender;

        //todo ��ӽ��ܼ��ܹ�� �� ���ܼ������ͷż��ֿܷ�Ϊ������ͬ�ļ���
        protected override void OnEnter()
        {
            base.OnEnter();

            sender = ((ActorGroup)parent).actor.GetComponent<Fighter>();
        }
    }
}