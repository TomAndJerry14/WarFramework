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

            var hitResult = HitResult.Fail;
            cmd.onHit = (_sender, _receiver, _hitResult) =>
            {
                Debug.Log("on hit => _sender:" + _sender?.name + " - _receiver: " + _receiver?.name + " - _hitResult: " + _hitResult);
                hitResult = _hitResult;
            };
            cmd.Excute();

            cmd.entity.TempHit();

            await UniTask.WaitUntil(() => cmd.cmdFinished);

            EndAction(hitResult == HitResult.Success);
        }
    }
}