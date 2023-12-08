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
        protected override void OnEnter()
        {
            if (data.modifyType == ModifyType.Quantify)
                Excute();
        }

        protected override void OnExit()
        {

        }
    }
}
