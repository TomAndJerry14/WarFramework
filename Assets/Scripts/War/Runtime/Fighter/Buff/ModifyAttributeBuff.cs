using Buff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    public class ModifyAttributeBuff : BuffBase
    {
        Action<BuffData> modify;

        public override BuffType BuffType => BuffType.ModifyAttriBute;

        protected override void InitParams(params object[] o)
        {
            modify = o[0] as Action<BuffData>;
        }

        protected override void OnEnter()
        {
            //TODO 进入时触发的情况
        }

        protected override void OnTick(float time)
        {
            modify?.Invoke(data);
        }

        protected override void OnExit()
        {

        }
    }
}
