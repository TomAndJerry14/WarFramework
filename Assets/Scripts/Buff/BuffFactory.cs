using Buff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    public static class BuffFactory
    {
        static Dictionary<BuffExistType, Type> typeDic = new Dictionary<BuffExistType, Type>();

        static BuffFactory()
        {
            var factoryAssembly = Assembly.GetAssembly(typeof(BuffFactory));
            Type[] types = factoryAssembly.GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                var type = types[i];
                if (type.BaseType == typeof(BuffBase))
                {
                    object o = Activator.CreateInstance(type);
                    if (o as BuffBase != null)
                    {
                        BuffExistType buffType = ((BuffBase)o).ExistType;
                        typeDic[buffType] = type;
                    }
                }
            }
        }

        public static BuffBase CreateBuff(BuffData data, Action<BuffData> action)
        {
            BuffBase buff = null;
            if (typeDic.TryGetValue(data.existType, out var type))
            {
                buff = (BuffBase)Activator.CreateInstance(type);
            }
            else
                buff = (BuffBase)Activator.CreateInstance(typeof(BuffBase));
            buff.Init(data, action);
            return buff;
        }
    }
}
