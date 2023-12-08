using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buff;

namespace War
{
    public class BuffComponent : IBuffComponent
    {

        readonly Dictionary<BuffExistType, List<BuffHandle>> handles = new Dictionary<BuffExistType, List<BuffHandle>>();

        public BuffComponent()
        {
            foreach (BuffExistType item in Enum.GetValues(typeof(BuffExistType)))
            {
                handles[item] = new List<BuffHandle>();
            }
        }


        public Action<BuffData> OnBuffExcute;

        public void Tick(float tickDeltaTime)
        {

            List<BuffHandle> removeList = new List<BuffHandle>();
            var _handles = handles[BuffExistType.Duratime];
            for (int i = 0; i < _handles.Count; i++)
            {
                if (_handles[i].IsValid)
                    _handles[i].Tick(tickDeltaTime);
                else
                    removeList.Add(_handles[i]);
            }

            _handles = handles[BuffExistType.Forever];
            for (int i = 0; i < _handles.Count; i++)
            {
                if (_handles[i].IsValid)
                    _handles[i].Tick(tickDeltaTime);
                else
                    removeList.Add(_handles[i]);
            }

            for (int i = 0; i < removeList.Count; i++)
            {
                Remove(removeList[i]);
            }
        }

        public void Add(BuffData data)
        {
            var _handles = handles[data.existType];

            for (int i = 0; i < _handles.Count; i++)
            {
                var handle = _handles[i];
                if (handle.Buff.Id == data.id && handle.Buff.Stackalbe)
                {
                    handle.stackCount++;
                    return;

                    //TODO 刷新时间 堆叠策略
                }
            }


            handles[data.existType].Add(new BuffHandle(BuffFactory.CreateBuff(data, OnBuffExcute)));
        }

        public void Remove(BuffHandle handle)
        {
            //TODO 先失效,移交到帧末尾结算
            handles[handle.Buff.ExistType].Remove(handle);
        }

        public void Remove(BuffData data)
        {
            //TODO  根据堆叠策略写
            throw new NotImplementedException();
        }

        public void SetInValid(BuffData data)
        {
            var _handles = handles[data.existType];
            for (int i = 0; i < _handles.Count; i++)
            {
                if (_handles[i].IsValid)
                    _handles[i].SetInValid();
            }
        }

        public void SendEvent(RoleEvent roleEvent)
        {
            List<BuffHandle> _handles = null;
            //TODO 这里其他种类也需要触发
            switch (roleEvent)
            {
                case RoleEvent.Attack:
                    _handles = handles[BuffExistType.NextAttack];
                    for (int i = 0; i < _handles.Count; i++)
                    {
                        _handles[i].Buff.Excute();
                        Remove(_handles[i]);
                    }
                    break;
                case RoleEvent.Skill:
                    _handles = handles[BuffExistType.NextSkill];
                    for (int i = 0; i < _handles.Count; i++)
                    {
                        _handles[i].Buff.Excute();
                        Remove(_handles[i]);
                    }
                    break;
                case RoleEvent.CancelSkill:

                    break;
                case RoleEvent.Died:
                    break;
                default:
                    break;
            }
        }

        public BuffBase[] GetBuffs()
        {
            throw new NotImplementedException();
        }

        public BuffBase[] GetBuffs(BuffTag cantAttck)
        {
            throw new NotImplementedException();
        }

        public BuffBase[] GetBuffs(BuffExistType type, BuffTag tag)
        {
            throw new NotImplementedException();
        }
    }
}
