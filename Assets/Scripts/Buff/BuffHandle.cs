using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Debug = UnityEngine.Debug;

namespace Buff
{
    public class BuffHandle : ITickTimeHandle
    {
        public bool Valid => this.buff != null;

        BuffBase buff;
        public BuffBase Buff => buff;

        public int StackCount
        {
            get
            {
                return this.buff == null ? 0 : StackCount;
            }
            set
            {
                if (this.buff != null)
                    this.buff.StackCount = value;
            }
        }

        public bool CantMove => Valid && buff.Tags.Contains(BuffTag.CantMove);

        public bool CantAttck => Valid && buff.Tags.Contains(BuffTag.CantAttck);

        public bool CantSelect => Valid && buff.Tags.Contains(BuffTag.CantSelect);

        private TickTimeHandle tickTimeHandle;
        public TickTimeHandle TickTimeHandle
        {
            get
            {
                return tickTimeHandle;
            }
        }

        public BuffHandle(BuffBase buff)
        {
            this.buff = buff;

            Debug.Log("BuffHandle New");

            if (buff.Data.deltaTime > 0)
            {
                float? dura = buff.Data.durationTime;
                if (buff.Data.existType == BuffExistType.Forever)
                    dura = null;

                tickTimeHandle = new TickTimeHandle(buff.Data.deltaTime, dura, BuffTick);
                tickTimeHandle.OnInValid += buff.TimeHandleInValid;
            }
        }


        public void Tick(float deltaTime)
        {
            if (!Valid)
                return;

            tickTimeHandle.Tick(deltaTime);
        }

        public void BuffTick(float deltaTime)
        {
            this.buff.Tick(deltaTime);
        }

        public void SetInValid()
        {
            this.buff.Exit();
            this.buff = null;
        }
    }
}
