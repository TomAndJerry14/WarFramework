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
    public class CreateEntityCommand : CommandBase
    {
        //’ŸªΩŒÔ
    private Bullet instantiation_entity;

        public Action<HitResult> onHit;

        public float survivalTime;

        public CommandPort outPort;

        public string gameObjectPath;

        public CreateEntityCommand(Fighter sender, string gameObjectPath, float survivalTime) : base(sender, null)
        {
            this.gameObjectPath = gameObjectPath;
            this.survivalTime = survivalTime;
        }

        public override async void Excute()
        {
            Debug.Log("Excute");
            outPort = new CommandPort();
            var entity = Resources.Load<GameObject>("Prefab/" + gameObjectPath).GetComponent<Bullet>();
            instantiation_entity = GameObject.Instantiate(entity);
            instantiation_entity.onHit += onHit;
            instantiation_entity.onHit += OnHit;
            instantiation_entity.Owner = sender;
            instantiation_entity.transform.parent = sender.transform;

            await UniTask.Delay(Mathf.CeilToInt(survivalTime * 1000));

            CmdFinished = true;
        }

        private void OnHit(HitResult _r)
        {
            Debug.Log($"HitPoint:{_r.hitPoint}");

            //CmdFinished = true;
        }


        public override void OnStop()
        {
            base.OnStop();

            Debug.Log("OnStop");
            instantiation_entity.onHit -= onHit;
            instantiation_entity.onHit -= OnHit;

            GameObject.Destroy(instantiation_entity.gameObject);
        }

    }
}