using System;
using UnityEngine;
#if UNITY_EDITOR
using Sirenix.OdinInspector;
#endif

namespace War
{
    [Serializable]
    public class MoveCommand : CommandBase
    {
        public MoveType moveType;

#if UNITY_EDITOR
        [ShowIf("moveType", MoveType.FixedSpeed)]
#endif
        public float speed;

#if UNITY_EDITOR
        [ShowIf("moveType", MoveType.FixedTime)]
#endif
        public float time;

        public Vector3 destination { get; set; }

        public bool isArrive;

        public MoveCommand(Fighter sender, MoveType moveType, float speedOrTime, Vector3 destination) : base(sender, null)
        {
            this.moveType = moveType;
            if (moveType == MoveType.FixedSpeed)
                this.speed = speedOrTime;
            else
                this.time = speedOrTime;
            this.destination = destination;
        }

        public override void Excute()
        {
            Debug.Log($"Move: sender->{sender.name}");
            Debug.Log($"Frame {WarScene.Instance.referees.CurFrame}");
            if (moveType == MoveType.FixedSpeed)
            {
                sender.TempMoveTo(destination, moveType, speed, () => { CmdFinished = true; isArrive = true; });
            }
            else
            {
                sender.TempMoveTo(destination, moveType, time, () => { CmdFinished = true; isArrive = true; });
            }

            //todo 
        }
    }
}