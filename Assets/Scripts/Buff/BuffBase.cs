using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Debug = UnityEngine.Debug;

namespace Buff
{
    public abstract class BuffBase 
    {
        //需要与Data种的ExistType对应，用于工厂反射创建实例
        public abstract BuffEnum registerType { get; }

        protected BuffData data;
        public BuffData Data => data;

        public int Id => data.id;
        public bool Stackalbe => data.stackable;

        private int stackCount;
        public int StackCount
        {
            get
            {
                return stackCount;
            }
            set
            {
                stackCount = value;
            }
        }

        public BuffTag[] Tags => data.tags;

        private Action<BuffData> modifyAction;
        private Action<BuffData> ModifyAction => modifyAction;

        public void Init(BuffData data, Action<BuffData> modify)
        {
            this.data = data;
            this.modifyAction = modify;

            Debug.Log("BuffBase Init");

            
        }

        public void Enter()
        {
            UnityEngine.Debug.Log("Enter");
            OnEnter();
        }

        public void Tick(float time)
        {
            Debug.Log("BuffBase Tick");

            OnTick(time);
        }

        protected virtual void OnTick(float time)
        {

        }

        public void TimeHandleInValid()
        {
            Debug.Log("BuffBase TimeHandleInValid");
            OnTimeHandleInValid();
        }

        protected virtual void OnTimeHandleInValid()
        {

        }

        public void Excute()
        {
            Debug.Log("BuffBase Excute");
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
            Debug.Log("Exit");
            OnExit();
        }
        protected virtual void OnExit()
        {

        }

        public virtual void SendEvent(RoleEvent roleEvent)
        {
           
        }
    }
}
