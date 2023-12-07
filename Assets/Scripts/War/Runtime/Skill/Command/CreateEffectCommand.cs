using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
#if UNITY_EDITOR
using Sirenix.OdinInspector;
#endif

namespace War
{
    [Serializable]
    public class CreateEffectCommand : CommandBase
    {

        private string effectResName;

        private float time;

        private Vector2 input;

        private Vector3 scale;

        private float survivalTime;

        public CreateEffectCommand(Fighter sender, float survivalTime, Vector2 input, string effectResName) : base(sender, null)
        {
            this.effectResName = effectResName;
            this.input = input;
            this.survivalTime = survivalTime;
            //this.scale = scale;
        }


        public override async void Excute()
        {
            var go = GameObject.Instantiate(Resources.Load<GameObject>("Effect/" + effectResName));
            go.transform.localPosition = new Vector3(input.x, 0, input.y);
            //go.transform.localScale = scale;


            //todo 

            await UniTask.Delay((int)(survivalTime * 1000));

            CmdFinished = true;
            GameObject.Destroy(go);
        }
    }
}