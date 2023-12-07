using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace War
{
    public interface ISendHit
    {
        public void Hit(HitResult result);
    }
}
