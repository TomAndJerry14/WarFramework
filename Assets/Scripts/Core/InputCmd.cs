using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct InputCmd
{
    //public KeyCode keyCode;

    public Vector2 mousePosition;

    public float time;

    public ActionEnum actionEnum;
}
