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
    public class CreateEntityCmd : CmdBase
    {
        //’ŸªΩŒÔ
        public Fighter entity;
        private Fighter instantiation_entity;

        public Action<HitResult> onHit;

        public float survivalTime;

        public CmdPort outPort;

        public override async void Excute()
        {
            Debug.Log("Excute");
            outPort = new CmdPort();
            instantiation_entity = GameObject.Instantiate(entity);
            instantiation_entity.onHit += onHit;
            instantiation_entity.onHit += OnHit;
            instantiation_entity.Owner = sender;

            await UniTask.Delay(Mathf.CeilToInt(survivalTime * 1000));

            CmdFinished = true;
        }

        private void OnHit(HitResult _r)
        {
            CmdFinished = true;
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