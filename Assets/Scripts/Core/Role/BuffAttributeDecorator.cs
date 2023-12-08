using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BuffAttributeDecorator : IAttributeGetter
{
    AttributeCom baseCom;
    AttributeCom attributeCom;
    public BuffAttributeDecorator(AttributeCom baseCom)
    {
        this.baseCom = baseCom;
        attributeCom = new AttributeCom();
    }

    public float this[AttributeType type] { get => attributeCom[type]; set => attributeCom[type] = value; }
}
