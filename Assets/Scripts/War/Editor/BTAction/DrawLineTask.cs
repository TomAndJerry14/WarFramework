using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace War
{
    [Category("Skill")]
    public class DrawLineTask : ActionTask
    {
        public DrawLineCmd cmd;

        protected override string OnInit()
        {
            cmd.receiver = this.ownerSystemAgent.gameObject.GetComponent<Fighter>();

            cmd.sender = this.ownerSystemAgent.gameObject.GetComponent<Fighter>();

            return base.OnInit();
        }

        protected override async void OnExecute()
        {
            base.OnExecute();

            cmd.Excute();
          
            await UniTask.WaitUntil(() => cmd.CmdFinished);

            EndAction(true);
        }
    }
}