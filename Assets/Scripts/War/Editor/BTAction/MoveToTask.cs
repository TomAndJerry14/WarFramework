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
        public MoveCommand moveCmd;

        protected override string OnInit()
        {
            moveCmd.receivers = new Fighter[] { this.ownerSystemAgent.gameObject.GetComponent<Fighter>() };

            moveCmd.sender = this.ownerSystemAgent.gameObject.GetComponent<Fighter>();

            return base.OnInit();
        }

        protected override async void OnExecute()
        {
            base.OnExecute();

            moveCmd.Excute();

            await UniTask.WaitUntil(() => moveCmd.CmdFinished);

            EndAction(true);
        }
    }
}