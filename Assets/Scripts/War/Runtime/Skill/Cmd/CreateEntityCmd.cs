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

        public Action<Fighter, Fighter, HitResult> onHit;

        public int survivalTime;

        public override async void Excute()
        {
            entity = new GameObject().AddComponent<Fighter>();
            entity.onHit += onHit;
            entity.onHit += OnHit;
            entity.Owner = sender;

            await UniTask.Delay(survivalTime);

            cmdFinished = true;
        }

        private void OnHit(Fighter _s, Fighter _f, HitResult _r)
        {
            cmdFinished = true;
        }

        public override void OnStop()
        {
            base.OnStop();

            entity.onHit -= onHit;
            entity.onHit -= OnHit;

            GameObject.Destroy(entity.gameObject);
        }

    }
}