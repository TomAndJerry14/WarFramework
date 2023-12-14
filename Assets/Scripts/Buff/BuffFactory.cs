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
        static Dictionary<BuffEnum, Type> typeDic = new Dictionary<BuffEnum, Type>();

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
                        var buffType = ((BuffBase)o).registerType;
                        typeDic[buffType] = type;
                    }
                }
            }
        }

        public static BuffBase CreateBuff(BuffData data, Action<BuffData> action)
        {
            BuffBase buff = null;

            if (typeDic.TryGetValue(data.registerType, out var type))
                buff = (BuffBase)Activator.CreateInstance(type);
            else
                throw new Exception($"没有{data.registerType}的class");

            buff.Init(data, action);
            return buff;
        }
    }
}
