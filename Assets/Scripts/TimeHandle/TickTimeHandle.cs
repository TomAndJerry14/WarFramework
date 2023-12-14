using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TickTimeHandle
{
    float? durationTime;
    float deltaTime;
    float lastTickTime;
    float tickTime;
    bool forever;
    public event Action OnInValid;

    public readonly Action<float> onTick;

    public bool Valid { get; set; }

    public TickTimeHandle(float deltaTime, float? durationTime = null, Action<float> onTick = null)
    {
        tickTime = 0f;
        lastTickTime = 0f;
        this.deltaTime = deltaTime;
        this.durationTime = durationTime;
        this.onTick = onTick;
        Valid = true;

        if (this.deltaTime == 0f)
            throw new SystemException("间隔不能为0");
    }

    public void Tick(float deltaTickTime)
    {
        if (!Valid)
            return;
        if (durationTime != null && lastTickTime >= durationTime)
        {
            SetInValid();
            return;
        }

        while (tickTime >= deltaTime)
        {
            lastTickTime += tickTime;
            tickTime = 0f;
            onTick.Invoke(lastTickTime);
            UnityEngine.Debug.Log($"<color=#55123F>{lastTickTime}</color>");
        }

        tickTime += deltaTickTime;
    }

    public void SetInValid()
    {
        Valid = false;
        OnInValid?.Invoke();
        OnInValid = null;
    }

}
