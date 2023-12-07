using Cysharp.Threading.Tasks;
using UnityEngine;

namespace War
{
    public class SkillBase
    {        
        public SkillData data;

        private bool finish = false;
        public bool Finish { get => finish; }

        public WarReferees.Frame[] cmdFrames;

        public int StartFrame { get; private set; }


        public SkillBase()
        {

        }

        public void Init(SkillData data, Fighter sender, Vector2 input, Fighter[] receivers = null)
        {
            cmdFrames = new WarReferees.Frame[data.eventData.Length];
            for (int i = 0; i < cmdFrames.Length; i++)
            {
                var eventData = data.eventData[i];

                cmdFrames[i] = new WarReferees.Frame(eventData.time, CommandFactory.CreateCommand(sender, eventData, input, receivers));
            }

            this.data = data;
        }

        public void Enter()
        {
            StartFrame = WarScene.Instance.referees.CurFrame;

            finish = false;

            OnEnter();
        }
        protected virtual void OnEnter()
        {

        }


        public void Tick()
        {
            if (finish)
                return;

            int count = 0;

            for (int i = 0; i < cmdFrames.Length; i++)
            {
                if (cmdFrames[i] != null) 
                {
                    if (StartFrame + cmdFrames[i].frameCount == WarScene.Instance.referees.CurFrame)
                    {
                        Debug.Log($"<color=#168A5F>insert skill command i:{i} WarScene Frame: { WarScene.Instance.referees.CurFrame}  Commoand:{cmdFrames[i].cmd.ToString()}</color>");

                        WarScene.Instance.referees.InsertCmd(cmdFrames[i].cmd);
                        cmdFrames[i] = null;
                    }
                }
                else
                {
                    count++;
                }
                //TODO 技能二阶段以及二阶段持续时间, 前摇后摇，计算冷却时间点, 预输入。。
            }

            if (count == cmdFrames.Length)
                finish = true;

        }


        public void Cancel()
        {
            finish = true;
        }

        public void Release()
        {

        }
    }
}
