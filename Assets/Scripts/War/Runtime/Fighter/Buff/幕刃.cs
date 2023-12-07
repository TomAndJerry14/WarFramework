using Buff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    public class 幕刃_不可选中 : BuffBase
    {
        public override BuffType BuffType => BuffType.CantSelect;

        public override void Excute()
        {
            throw new NotImplementedException();
        }

        protected override void InitParams(params object[] o)
        {
            throw new NotImplementedException();
        }
    }

    public class 幕刃_下一击增加伤害 : BuffBase
    {
        public override BuffType BuffType => BuffType.NextAttackEffect;

        public override void Excute()
        {
            throw new NotImplementedException();
        }

        protected override void InitParams(params object[] o)
        {
            throw new NotImplementedException();
        }

        
    }
}
