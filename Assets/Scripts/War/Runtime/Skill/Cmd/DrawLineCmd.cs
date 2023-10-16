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
    public class DrawLineCmd : CmdBase
    {
        public int time;

        public override async void Excute()
        {
            LineRenderer renderer = new GameObject().AddComponent<LineRenderer>();
            renderer.SetPositions(new Vector3[]
            {
                sender.transform.position,
                receiver.transform.position,
            });
            renderer.loop = true;

            Debug.Log("»­Ïß");
            await UniTask.Delay(time * 1000);

            CmdFinished = true;
        }
    }
}