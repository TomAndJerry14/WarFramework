using NodeCanvas.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintTask : ActionTask
{

    public string message;

    protected override string OnInit()
    {
        return base.OnInit();
    }

    protected override void OnExecute()
    {
        base.OnExecute();

        Debug.Log(message);
    }

    protected override void OnUpdate()
    {
        if (elapsedTime >= 1)
        {
            EndAction(true);
        }
    }
}
