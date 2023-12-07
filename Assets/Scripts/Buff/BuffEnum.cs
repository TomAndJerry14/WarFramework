using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buff
{
    public enum BuffType
    {
        None,
        ModifyAttriBute,

        NextAttackEffect,

        CantSelect,
    }

    public enum BuffTag
    {
        CantMove,
        CantAttck,
        CantSelect,
    }
}
