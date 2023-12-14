using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

[Serializable]
public class AttributeComponent : IAttributeGetter
{
    [ShowInInspector]
    private float hp = 100;
    public float Hp
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }

    protected Dictionary<AttributeType, float> attrDic = new Dictionary<AttributeType, float>();
    public AttributeComponent()
    {
        foreach (AttributeType item in Enum.GetValues(typeof(AttributeType)))
        {
            attrDic[item] = 0f;
        }
    }

    public float this[AttributeType type]
    {
        get
        {
            return attrDic[type];
        }
        set
        {
            attrDic[type] = value;
        }
    }
}

    