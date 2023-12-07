using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace War
{
    [Serializable]
    public class ReceiveInputResult : IResult
    {
        public enum Result
        {
            Success,
            Fail,
        }

        public Result result;

        public KeyCode keyCode;
        public Vector3 mousePosition;

        public ReceiveInputResult()
        {

        }

        public ReceiveInputResult(KeyCode keyCode, Vector3 mousePosition)
        {
            this.keyCode = keyCode;
            this.mousePosition = mousePosition;
        }
    }
}