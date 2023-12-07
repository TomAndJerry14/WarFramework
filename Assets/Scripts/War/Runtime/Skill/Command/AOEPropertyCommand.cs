using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace War
{
    public class AOEPropertyCommand : CommandBase
    {
        private AreaData areaData;
        private EffectEnum effectEnum;
        private float value;
        private Vector2 input;
        public AOEPropertyCommand(Fighter sender, Vector2 input, AreaData areaData, EffectEnum effectEnum, float value) : base(sender, null)
        {
            this.areaData = areaData;
            this.effectEnum = effectEnum;
            this.value = value;
            this.input = input;
        }

        public override void Excute()
        {
            var fighters = areaData.GetAOITarger(input);

            for (int i = 0; i < fighters.Length; i++)
            {
                var fighter = fighters[i];
                if (fighter)
                {
                    switch (effectEnum)
                    {
                        case EffectEnum.Friend:
                            if (fighter.teamEnum == sender.teamEnum)
                            {
                                fighter.AttrCom.Hp += value;
                            }
                            break;
                        case EffectEnum.Enemy:
                            if (fighter.teamEnum != sender.teamEnum)
                            {
                                fighter.AttrCom.Hp += value;
                            }
                            break;
                        case EffectEnum.All:
                            fighter.AttrCom.Hp += value;
                            break;
                    }
                }
            }

            CmdFinished = true;
        }

        public override void OnStop()
        {

        }

        public override string ToString()
        {
            return $"{base.ToString()} Effect:{effectEnum} value:{value}";
        }
    }
}
