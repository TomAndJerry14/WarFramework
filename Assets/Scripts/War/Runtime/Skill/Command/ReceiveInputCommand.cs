using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace War
{
    public class ReceiveInputCommand : CommandBase
    {

        public float survivalTime;

        public ReceiveInputResult result;

        public ReceiveInputCommand(Fighter sender, Fighter[] receivers = null) : base(sender, receivers)
        {

        }

        public override async void Excute()
        {
            throw new NotImplementedException();

            if (result.result == ReceiveInputResult.Result.Success)
                CmdFinished = true;


            await UniTask.Delay(Mathf.CeilToInt(survivalTime * 1000));

            CmdFinished = true;
        }
    }
}