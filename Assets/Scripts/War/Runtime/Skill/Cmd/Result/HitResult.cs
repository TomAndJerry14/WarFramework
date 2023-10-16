using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace War
{
    [Serializable]
    public class HitResult : IResult
    {
        public enum Result
        {
            Success,
            Fail,
            Other,
        }

        public Result result;

        public Fighter Sender;
        public Fighter Receiver;
        public Vector3 hitPoint;

        public HitResult(Fighter sender, Fighter receiver, Vector3 hitPoint, Result result)
        {
            this.Sender = sender;
            this.Receiver = receiver;
            this.hitPoint = hitPoint;
            this.result = result;
        }



    }
}