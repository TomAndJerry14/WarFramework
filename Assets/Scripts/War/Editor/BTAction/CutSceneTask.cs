using NodeCanvas.Framework;
using Slate;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections.Generic;

namespace War
{

    [ParadoxNotion.Design.Category("Skill")]
    public class CutSceneTask : ActionTask
    {
        public Cutscene cutScene;
        private Cutscene _cutScene;

        public Dictionary<string, IResult> resultDict;

        protected override void OnExecute()
        {
            base.OnExecute();

            Play();
        }

        protected override string info => "²¥·Åcut scene";

        protected override string OnInit()
        {
            blackboard.SetVariableValue("sender", this.ownerSystemAgent.gameObject);
            resultDict = blackboard.GetVariable("outputResult").value as Dictionary<string, IResult> ?? new Dictionary<string, IResult>();
            Debug.Log("OnInit sender => " + this.ownerSystemAgent.gameObject);
            return base.OnInit();
        }

        public void Play()
        {
            if (_cutScene == null)
                _cutScene = Object.Instantiate(cutScene);

            var sender = blackboard.GetVariable<GameObject>("sender").value;
            Debug.Log("sender => " + sender);
            _cutScene.SetGroupActorOfName("Skill", sender);
            Debug.Log("Run cut scene -> " + cutScene.name);
            _cutScene.Play();
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();


            var dict = _cutScene.GetResult();
            foreach (var kv in dict)
            {
                resultDict[kv.Key] = kv.Value;
            }
            blackboard.SetVariableValue("outputResult", resultDict);

            if (_cutScene.currentTime >= _cutScene.playTimeMax)
                EndAction();
        }

        protected override void OnStop()
        {
            base.OnStop();

            Object.Destroy(_cutScene);
            Object.Destroy(_cutScene.gameObject);
        }
    }
}