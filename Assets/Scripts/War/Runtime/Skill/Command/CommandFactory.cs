using System;
using System.Collections.Generic;
using UnityEngine;

namespace War
{
    internal static class CommandFactory
    {
        public static CommandBase CreateCommand(Fighter sender, SkillEventData eventData, Vector2 input, Fighter[] receivers = null)
        {
            CommandBase cmd = null;
            switch (eventData.eventType)
            {
                case EventType.Translate:
                    throw new NotImplementedException("TODO");
                    break;
                case EventType.AOEPropertyChange:
                    cmd = new AOEPropertyCommand(sender, input, eventData.areaData, eventData.effectEnum, eventData.value);
                    break;
                case EventType.Effect:
                    cmd = new CreateEffectCommand(sender, eventData.survivalTime, input, "EffectA");
                    break;
                case EventType.Bullet:
                    cmd = new CreateEntityCommand(sender, eventData.gameObjectPath, eventData.survivalTime);
                    break;

                    //TODO 每次多加一个新类型，都需要来这里新写，很不自由
            }
            return cmd;
        }
    }
}
