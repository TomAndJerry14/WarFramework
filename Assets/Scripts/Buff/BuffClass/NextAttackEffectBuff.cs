using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buff
{
    public class NextAttackEffectBuff : BuffBase
    {
        public  BuffExistType ExistType => BuffExistType.NextAttack;


        protected override void OnExcute()
        {
            Exit();
        }
    }
}
