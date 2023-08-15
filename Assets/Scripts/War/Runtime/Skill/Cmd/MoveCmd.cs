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
    public class MoveCmd : CmdBase
    {
        public MoveType moveType;

        [ShowIf("moveType", MoveType.FixedSpeed)]
        public float speed;

        [ShowIf("moveType", MoveType.FixedTime)]
        public float time;

        public Vector3 destination;

        public bool isArrive;

        public override void Excute()
        {
            if (moveType == MoveType.FixedSpeed)
            {
                receiver.TempMoveTo(destination, moveType, speed, (b) => { cmdFinished = true; isArrive = b; });
            }
            else
            {
                receiver.TempMoveTo(destination, moveType, time, (b) => { cmdFinished = true; isArrive = b; });
            }

            //todo 
        }
    }
}