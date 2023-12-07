using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Buff
{
    public static class BuffFactory
    {
        static Dictionary<BuffType, Type> typeDic = new Dictionary<BuffType, Type>();

        static BuffFactory()
        {
            var assembly = Assembly.GetAssembly(typeof(BuffType));
            Type[] types = assembly.GetTypes();
            for (int i = 0; i < types.Length; i++)
            {
                var type = types[i];
                if (type.BaseType == typeof(BuffBase))
                {
                    object o = Activator.CreateInstance(type, null);
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
            return (BuffBase)Activator.CreateInstance(typeDic[data.type], o);
        }
    }
}
