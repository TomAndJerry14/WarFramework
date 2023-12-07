using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TickTimeHandle
{
    float durationTime;
    float deltaTime;
    float lastTickTime;
    float tickTime;


    public readonly Action<float> onTick;

    public bool IsValid => lastTickTime <= this.durationTime;

    public TickTimeHandle(float durationTime, float deltaTime, Action<float> onTick)
    {
        tickTime = 0f;
        lastTickTime = 0f;
        this.deltaTime = deltaTime;
        this.durationTime = durationTime;
        this.onTick = onTick;

        if (this.deltaTime == 0f)
            throw new SystemException("间隔不能为0");
    }

    public void Tick(float deltaTickTime)
    {
        if (!IsValid)
            return;

        while (tickTime >= deltaTime )
        {
            lastTickTime += tickTime;
            tickTime = 0f;
            onTick.Invoke(lastTickTime);
            UnityEngine.Debug.Log($"<color=#55123F>{lastTickTime}</color>");
        }

        tickTime += deltaTickTime;        
    }
}
