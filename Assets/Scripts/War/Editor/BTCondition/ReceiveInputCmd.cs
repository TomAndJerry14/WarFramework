using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace War
{
    [Serializable]
    public struct ReceiveInputCmd
    {
        public ReceiveInputCmdType type;

        [ShowIf("type", (int)ReceiveInputCmdType.KeyCode)]
        public KeyCode keyCode;

        [ShowIf("type", (int)ReceiveInputCmdType.Mouse)]
        public int mouseButtonIndex;

        [ShowIf("type",(int)ReceiveInputCmdType.Mouse )]
        public Vector2 mousePosition;

        [ShowIf("type", (int)ReceiveInputCmdType.Mouse)]
        public Vector2 mouseRange;
    }
}