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
        public DrawLineCommand cmd;

        protected override string OnInit()
        {
            cmd.receivers = new Fighter[] { this.ownerSystemAgent.gameObject.GetComponent<Fighter>() };

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