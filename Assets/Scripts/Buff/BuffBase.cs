using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buff
{
    public class BuffBase : ITickTimeHandle
    {
        protected BuffData data;
        public BuffData Data => data;

        public BuffExistType ExistType { get; }


        public int Id => data.id;
        public bool Stackalbe => data.stackable;

        public BuffTag[] Tags => data.tags;

        private bool isValid;
        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }



        private TickTimeHandle tickTimeHandle;
        public TickTimeHandle TickTimeHandle
        {
            get;
        }

        private Action<BuffData> modifyAction;
        private Action<BuffData> ModifyAction => modifyAction;

        public void Init(BuffData data, Action<BuffData> modify)
        {
            this.data = data;
            this.modifyAction = modify;
            if (data.deltaTime > 0)
                tickTimeHandle = new TickTimeHandle(data.durationTime, data.deltaTime, Tick);
        }

        public void Enter()
        {
            UnityEngine.Debug.Log("Enter");
            OnEnter();
        }

        void Tick(float time)
        {
            OnTick(time);
            if (!tickTimeHandle.IsValid)
            {
                Exit();
                UnityEngine.Debug.Log("Time Handle Exit");
            }
        }

        protected virtual void OnTick(float time)
        {

        }

        public void Excute()
        {
            ModifyAction?.Invoke(this.data);
            OnExcute();
        }
        protected virtual void OnExcute()
        {

        }


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
