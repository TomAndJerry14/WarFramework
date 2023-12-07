using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace War
{
    public abstract class CommandBase
    {
        public Fighter sender;

        public Fighter[] receivers;

        public CommandBase(Fighter sender, Fighter[] receivers = null)
        {
            this.sender = sender;
            this.receivers = receivers;
        }

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

        public override string ToString()
        {
            return $"type:{GetType()}  sender:{sender.gameObject.name}";
        }
    }
}