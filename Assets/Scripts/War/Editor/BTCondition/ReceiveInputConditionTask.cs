using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;

namespace War
{
    [ParadoxNotion.Design.Category("Skill")]
    public class ReceiveInputConditionTask : ConditionTask
    {
        public ReceiveInputCmd[] cmds;

        public float receiveTime;
        private float recordTime;

        private List<ReceiveInputCmd> records = new List<ReceiveInputCmd>();


        protected override void OnEnable()
        {
            base.OnEnable();

            records.Clear();
            recordTime = 0f;
        }

        protected override bool OnCheck()
        {
            if (Input.anyKey)
            {
                var len = records.Count;

                Debug.Log("len =>: " + len);

                if (len >= cmds.Length)
                {
                    blackboard.SetVariableValue("receiveInputCmdSuccess", true);
                    return true;
                }
                var info = cmds[len];

                if (info.type == ReceiveInputCmdType.KeyCode && Input.GetKeyDown(info.keyCode))
                {
                    records.Add(info);
                    return false;
                }

                var mousePostion = Input.mousePosition;
                if (info.type == ReceiveInputCmdType.Mouse
                    && Input.GetMouseButton(info.mouseButtonIndex)
                    && Mathf.Abs(mousePostion.x - info.mousePosition.x) <= info.mouseRange.x
                    && Mathf.Abs(mousePostion.y - info.mousePosition.y) <= info.mouseRange.y)
                {
                    records.Add(info);
                    return false;
                }
            }

            recordTime += Time.deltaTime;
            if (recordTime >= receiveTime)
            {
                blackboard.SetVariableValue("receiveInputCmdSuccess", false);
                return true;
            }

            return false;
        }

    }
}