using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Debug = UnityEngine.Debug;

namespace War
{
    public class WarReferees
    {
        const float oneFrameTime = 0.33f;
        public class Frame
        {
            public Frame(float time, CommandBase cmd)
            {
                this.time = time;
                frameCount = (int)(time / oneFrameTime);
                this.cmd = cmd;
            }
            public int frameCount;
            public float time;
            public CommandBase cmd;
        }

        public float Time
        {
            get; set;
        }
        public int CurFrame
        {
            get; set;
        }



        //替换成最小堆
        List<Frame> containers = new List<Frame>();

        List<SkillBase> skills = new List<SkillBase>();

        public void InsertCmd(CommandBase cmd)
        {
            containers.Add(new Frame(Time, cmd));
        }

        public void Tick()
        {
            Time += UnityEngine.Time.deltaTime;
            var frame = (int)(Time / oneFrameTime);

            if (CurFrame == frame)
                return;
            //Debug.Log($"<color=#C63985>CurFrame: {CurFrame}</color>"); 
            CurFrame = frame;

            TickSkill();
            TickCommand();
        }

        private void TickCommand()
        {
            List<Frame> removeList = new List<Frame>();
            for (int i = 0; i < containers.Count; i++)
            {
                if (containers[i].frameCount <= CurFrame)
                {
                    containers[i].cmd.Excute();
                    removeList.Add(containers[i]);
                }
            }

            for (int i = removeList.Count - 1; i >= 0; i--)
            {
                containers.Remove(removeList[i]);
            }
        }

        public void InsertSkill(SkillBase skill)
        {
            skills.Add(skill);
            skill.Enter();
            skill.Tick();            
        }

        private void TickSkill()
        {
            for (int i = skills.Count - 1; i >= 0; i--)
            {
                var skill = skills[i];
                skill.Tick();
                if (skill.Finish)
                {
                    skills.Remove(skill);
                }
            }
        }
    }
}
