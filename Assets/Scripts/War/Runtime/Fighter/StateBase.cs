using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Debug = UnityEngine.Debug;

namespace War
{
    public abstract class StateBase
    {
        public abstract StateEnum StateEnum
        {
            get;
        }

        public void Enter()
        {
            Debug.Log($"Enter State: {StateEnum}");
        }

        public void Exit()
        {
            Debug.Log($"Exit State: {StateEnum}");
        }
    }

    public class Test1State : StateBase
    {
        public override StateEnum StateEnum => StateEnum.Test1;
    }
    public class Test2State : StateBase
    {
        public override StateEnum StateEnum => StateEnum.Test2;
    }
    public class Test3State : StateBase
    {
        public override StateEnum StateEnum => StateEnum.Test3;
    }
    public class Test4State : StateBase
    {
        public override StateEnum StateEnum => StateEnum.Test4;
    }
}
