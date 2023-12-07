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

        public ISendHit Sender;
        public IReceiveHit Receiver;
        public Vector3 hitPoint;

        public HitResult(ISendHit sender, IReceiveHit receiver, Vector3 hitPoint, Result result)
        {
            this.Sender = sender;
            this.Receiver = receiver;
            this.hitPoint = hitPoint;
            this.result = result;
        }



    }
}