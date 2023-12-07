using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buff
{
    public interface IBuffComponent
    {
        public List<BuffHandle> Handles { get; }

        public void Add(BuffData data);
        public void Tick(float tickDeltaTime);
        public void Remove(BuffData data);

        public bool CanMove { get; }

        public bool CanAttck { get; }

        public bool CanSelect { get; }

    }
}
