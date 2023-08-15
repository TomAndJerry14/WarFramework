using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace War
{
    [Category("Skill")]
    public class MoveToTask : ActionTask
    {
        public MoveCmd moveCmd;

        protected override string OnInit()
        {
            moveCmd.receiver = this.ownerSystemAgent.gameObject.GetComponent<Fighter>();

            moveCmd.sender = this.ownerSystemAgent.gameObject.GetComponent<Fighter>();

            return base.OnInit();
        }

        protected override async void OnExecute()
        {
            base.OnExecute();

            moveCmd.Excute();

            await UniTask.WaitUntil(() => moveCmd.cmdFinished);

            EndAction(true);
        }
    }
}