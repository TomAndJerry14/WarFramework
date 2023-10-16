using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace War
{
    [Category("Skill")]
    public class CreateEntityTask : ActionTask
    {
        public CreateEntityCmd cmd;

        protected override string OnInit()
        {
            cmd.receiver = this.ownerSystemAgent.gameObject.GetComponent<Fighter>();

            cmd.sender = this.ownerSystemAgent.gameObject.GetComponent<Fighter>();

            return base.OnInit();
        }

        protected override async void OnExecute()
        {
            base.OnExecute();

            var hitResult = HitResult.Result.Fail;
            cmd.onHit = (_hitResult) =>
            {
                Debug.Log("on hit => _sender:" + _hitResult.Sender?.name + " - _receiver: " + _hitResult.Receiver?.name + " - _hitMsg: " + _hitResult.result);
                hitResult = _hitResult.result;
            };
            cmd.Excute();

            await UniTask.WaitUntil(() => cmd.CmdFinished);

            EndAction(hitResult == HitResult.Result.Success);
        }
    }
}