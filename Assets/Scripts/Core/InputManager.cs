using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    Dictionary<ActionEnum, KeyCode> actionMap = new Dictionary<ActionEnum, KeyCode>()
    {
        {ActionEnum.SkillKeyCode1, KeyCode.Q },
        {ActionEnum.SkillKeyCode2, KeyCode.W },
    };


    Queue<InputCmd> queue = new Queue<InputCmd>();

    private void Update()
    {
        foreach (var mapItem in actionMap)
        {
            if (Input.GetKeyUp(mapItem.Value))
            {
                queue.Enqueue(new InputCmd() { actionEnum = mapItem.Key, mousePosition = Input.mousePosition, time = Time.realtimeSinceStartup });
                Debug.Log(mapItem.Key + " - " + Input.mousePosition);
            }

            for (int i = 10; i < queue.Count; i++)
            {
                queue.Dequeue();
            }
        }
    }

    public Queue<InputCmd> GetQueue()
    {
        return queue;
    }
}
