using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using Sirenix.OdinInspector;
#endif

namespace War
{
    [Serializable]
    public class CreateEffectCmd : CmdBase
    {

        public string effectResName;

        public float time;

        public Vector3 offset;

        public override void Excute()
        {
            var go = GameObject.Instantiate(Resources.Load<GameObject>("Effect/" + effectResName));
            go.transform.localPosition = offset;

            //todo 
        }
    }
}