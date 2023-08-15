using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace War
{
    public abstract class CmdBase
    {
        public Fighter sender;

        public Fighter receiver;

        public bool cmdFinished = false;

        public abstract void Excute();

        public void Stop() 
        {
            throw new System.NotImplementedException();
        }

        public virtual void OnStop()
        {

        }
    }
}