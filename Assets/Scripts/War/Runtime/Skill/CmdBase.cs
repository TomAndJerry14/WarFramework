using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace War
{
    public abstract class CmdBase
    {
        public Fighter sender;

        public Fighter receiver;

        private bool cmdFinished = false;
        public bool CmdFinished
        {
            get
            {
                return cmdFinished;
            }
            set
            {
                if (!cmdFinished)
                    Stop();
                cmdFinished = value;
            }
        }

        public abstract void Excute();

        private void Stop()
        {
            OnStop();
        }

        public virtual void OnStop()
        {

        }
    }
}