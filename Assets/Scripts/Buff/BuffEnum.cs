using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buff
{
    public enum BuffEnum
    {
        ModifyAttribute,



        UseSkill,


    }
    public enum BuffType
    {
        AttriBute,
        State,
    }

    //存在方式
    public enum BuffExistType
    {
        Once,

        Duratime,
        Forever,

        NextAttack,
        NextSkill,
    }

    public enum BuffTag
    {
        ModifyAttribute,
        FixedAttribute,

        CantMove,
        CantAttck,
        CantSelect,



        Hide,//隐身        
    }

    //触发时机事件
    public enum RoleEvent
    {
        Attack,//玩家攻击时

        OnHit,

        Skill,
        CancelSkill,

        Died,
    }

    //修改方式
    public enum ModifyType
    {
        Change,//直接修改
        Quantify,//定量
        Increment,//增量
    }
}
