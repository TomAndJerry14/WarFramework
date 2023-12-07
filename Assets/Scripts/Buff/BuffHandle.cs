using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buff
{
    public class BuffHandle
    {
        private int id;
        public int Id => id;

        public bool IsValid => this.buff != null;

        BuffBase buff;
        public BuffBase Buff => buff;

        public int stackCount = 0;


        public BuffHandle(BuffBase buff)
        {
            this.buff = buff;
        }

        public bool CantMove => IsValid && buff.Tags.Contains(BuffTag.CantMove);

        public bool CantAttck => IsValid && buff.Tags.Contains(BuffTag.CantAttck);

        public bool CantSelect => IsValid && buff.Tags.Contains(BuffTag.CantSelect);

        public void Tick(float deltaTime)
        {
            if (!IsValid)
                return;

            if (buff.TickTimeHandle.IsValid)
                buff.TickTimeHandle.Tick(deltaTime);
            else
            {
                buff.Exit();
                this.buff = null;
            }
        }
    }
}
