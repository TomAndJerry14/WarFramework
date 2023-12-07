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
        static Dictionary<BuffType, Type> typeDic = new Dictionary<BuffType, Type>();

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
                        BuffType buffType = ((BuffBase)o).BuffType;
                        typeDic[buffType] = type;
                    }


                }
            }
        }

        public static BuffBase CreateBuff(BuffData data, params object[] o)
        {
            var buff = (BuffBase)Activator.CreateInstance(typeDic[data.type]);
            buff.Init(data, o);
            return buff;
        }
    }
}
