using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IAttributeGetter
{
    public float this[AttributeType type] { get; set; }
}