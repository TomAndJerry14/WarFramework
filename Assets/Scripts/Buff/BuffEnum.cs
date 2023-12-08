using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buff
{
    public enum BuffType
    {
        AttriBute,
        State,//这种只是相当于一个变量，用于给上层获取
        Event,//触发一个事件
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
        Cure,
        Hurt,

        SpeedUp,
        SpeedDown,

        AttackUp,
        AttackDown,

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

    //触发条件

    //修改方式
    public enum ModifyType
    {
        Change,//直接修改
        Quantify,//定量
        Increment,//增量
    }
}
