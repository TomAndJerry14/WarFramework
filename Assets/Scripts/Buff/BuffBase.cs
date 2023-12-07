using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buff
{
    public abstract class BuffBase : ITickTimeHandle
    {
        protected BuffData data;

        public int Id => data.id;
        public bool Stackalbe => data.stackable;

        public BuffTag[] Tags => data.tags;

        public abstract BuffType BuffType
        {
            get;
        }

        private TickTimeHandle tickTimeHandle;
        public TickTimeHandle TickTimeHandle
        {
            get;
        }

        public void Init(BuffData data, params object[] o)
        {
            this.data = data;
            tickTimeHandle = new TickTimeHandle(data.durationTime, data.deltaTime, Tick);
            InitParams(o);
        }

        protected abstract void InitParams(params object[] o);

        public void Enter()
        {
            UnityEngine.Debug.Log("Enter");
            OnEnter();
        }

        void Tick(float time)
        {
            OnTick(time);
        }

        protected virtual void OnTick(float time)
        {

        }

        public abstract void Excute();

        protected virtual void OnEnter()
        {

        }

        public void Exit()
        {
            UnityEngine.Debug.Log("Exit");
            OnExit();
        }
        protected virtual void OnExit()
        {

        }


    }
}
