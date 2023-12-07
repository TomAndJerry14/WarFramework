using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Debug = UnityEngine.Debug;

namespace War
{
    public class StateCtrl
    {
        private Queue<StateBase> stateQueue = new Queue<StateBase>();

        public Queue<StateBase> StateQueue
        {
            get
            {
                return stateQueue;
            }
        }

        public StateCtrl()
        {
            stateQueue.Enqueue(new IdleState());
        }

        public void Switch(StateBase state)
        {
            var lastState = StateQueue.Last();
            if (lastState.StateEnum == state.StateEnum)
            {
                stateQueue.Dequeue();
                lastState.Exit();
                stateQueue.Enqueue(state);
                state.Enter();
            }
            else if (lastState.StateEnum > state.StateEnum)
            {
                return;
            }
            else
            {
                stateQueue.Enqueue(state);
                state.Enter();
            }
        }
    }
}
