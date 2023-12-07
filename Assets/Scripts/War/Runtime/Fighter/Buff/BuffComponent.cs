using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buff;

namespace War
{
    public class BuffComponent :  IBuffComponent
    {

        List<BuffHandle> handles = new List<BuffHandle>();

        public Action<BuffData> OnBuffTick;

        public List<BuffHandle> Handles
        {
            get
            {
                return handles;
            }
        }

        public bool CanMove
        {
            get
            {
                for (int i = 0; i < Handles.Count; i++)
                {
                    if (Handles[i].CantMove)
                        return false;
                }
                return true;
            }
        }

        public bool CanAttck => throw new NotImplementedException();

        public bool CanSelect => throw new NotImplementedException();

        public void Tick(float tickDeltaTime)
        {
            UnityEngine.Debug.Log(CanMove);
            List<BuffHandle> removeList = new List<BuffHandle>();
            for (int i = 0; i < Handles.Count; i++)
            {
                if (Handles[i].IsValid)
                    Handles[i].Tick(tickDeltaTime);
                else
                    removeList.Add(Handles[i]);
            }

            //TODO 移交到帧末尾结算
            for (int i = 0; i < removeList.Count; i++)
            {
                Remove(removeList[i]);
            }
        }

        public void Add(BuffData data)
        {
            for (int i = 0; i < Handles.Count; i++)
            {
                var handle = Handles[i];
                if (handle.Buff.Id == data.id && handle.Buff.Stackalbe)
                {
                    handle.stackCount++;
                    return;

                    //TODO 刷新时间 堆叠策略
                }
            }

            handles.Add(new BuffHandle(BuffFactory.CreateBuff(data, OnBuffTick)));
        }

        public void Remove(BuffHandle handle)
        {
            handles.Remove(handle);
        }

        public void Remove(BuffData data)
        {
            //TODO  根据堆叠策略写
            throw new NotImplementedException();
        }
    }
}
