using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buff
{
    [Serializable]
    public class BuffData
    {
        
        public int id;

        public BuffEnum registerType;

        public string buffName;

        public int maxStack;

        public BuffType type;

        public BuffExistType existType;

        //优先级
        public int priority;

        public bool stackable;

        public BuffTag[] tags;

        public float durationTime;

        public float deltaTime;

        public ModifyType modifyType;

        public AttributeType attribute;

        public float value;

        public bool refreshTime;

    }
}
