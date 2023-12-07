using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    public class IdleState : StateBase
    {
        public override StateEnum StateEnum { get => StateEnum.Idle; }
    }
}
