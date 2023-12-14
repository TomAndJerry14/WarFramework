using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buff;
using Debug = UnityEngine.Debug;

namespace War
{
    public partial class BuffComponent
    {
        readonly List<BuffHandle> handles = new List<BuffHandle>();
        readonly Fighter owner;

        public AttributeComponent AttrCom { get => attrCom; }

        public float this[AttributeType type] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private AttributeComponent attrCom = new AttributeComponent();
        //锁死属性值字典
        //开启某个状态会使某个属性值锁死
        public Dictionary<AttributeType, float> fixedAttrDict = new Dictionary<AttributeType, float>();


        public BuffComponent(Fighter owner)
        {
            this.owner = owner;
        }
        void OnBuffExcute(BuffData data)
        {
            Debug.Log("OnBuffExcute");
            if (data.type == BuffType.AttriBute)
            {
                OnModifyAttributeBuffExcute(data);
            }
            else if (data.type == BuffType.State)
            {
                //TODO other type
                if (data.registerType == BuffEnum.UseSkill)
                {
                    owner.SkillCom.UseSkill((int)data.value);
                }
            }
        }

        private void OnModifyAttributeBuffExcute(BuffData data)
        {
            switch (data.modifyType)
            {
                case ModifyType.Change:
                    //在BuffComponent里获取是否有contain(BuffTag.FixedAttribute)
                    //如果有，直接生效，属性变更不起作用
                    break;
                case ModifyType.Quantify:
                    this[data.attribute] = data.value;
                    OnAttributeChanged(data.attribute);
                    break;
                case ModifyType.Increment:
                    this[data.attribute] += data.value;
                    OnAttributeChanged(data.attribute);
                    break;
                default:
                    break;
            }
        }

        void OnAttributeChanged(AttributeType attribute)
        {
            Debug.Log($"<color=#FF6600>type: {attribute}   value:{this[attribute]}</color>");
        }
    }
    public partial class BuffComponent : IBuffComponent, IAttributeGetter
    {

        public void Tick(float tickDeltaTime)
        {

            List<BuffHandle> removeList = new List<BuffHandle>();
            for (int i = 0; i < handles.Count; i++)
            {
                if (handles[i].Valid)
                    handles[i].Tick(tickDeltaTime);
                else
                    removeList.Add(handles[i]);
            }

            for (int i = 0; i < removeList.Count; i++)
            {
                Remove(removeList[i]);
            }
        }

        public void Add(BuffData data)
        {
            for (int i = 0; i < handles.Count; i++)
            {
                var handle = handles[i];
                if (!handle.Valid)
                    continue;
                if (handle.Buff.Id == data.id && handle.Buff.Stackalbe)
                {
                    handle.StackCount++;
                    return;

                    //TODO
                    //刷新时间
                    //堆叠策略
                    //同类型会直接挤掉 -> (锁死攻击力1 会被 锁死攻击力100)挤掉
                }
            }

            this.handles.Add(new BuffHandle(BuffFactory.CreateBuff(data, OnBuffExcute)));
        }

        public void Remove(BuffHandle handle)
        {
            //TODO 先失效,移交到帧末尾结算
            handles.Remove(handle);
        }

        public void Remove(BuffData data)
        {
            //TODO  根据堆叠策略写
            throw new NotImplementedException();
        }

        public void SetInValid(BuffData data)
        {
            for (int i = 0; i < handles.Count; i++)
            {
                if (handles[i].Valid)
                    handles[i].SetInValid();
            }
        }

        public void SendEvent(RoleEvent roleEvent)
        {
            for (int i = 0; i < handles.Count; i++)
            {
                if (handles[i].Valid)
                    handles[i].Buff.SendEvent(roleEvent);
            }
        }

        public BuffBase[] GetBuffs(BuffTag cantAttck)
        {
            throw new NotImplementedException();
        }

        public BuffBase[] GetBuffs(BuffExistType type, BuffTag tag)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            this.handles.Clear();
        }


        
    }
}
