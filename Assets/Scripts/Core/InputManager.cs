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

    Dictionary<ActionEnum, KeyCode> inputMap = new Dictionary<ActionEnum, KeyCode>()
    {
        {ActionEnum.SkillKeyCode1, KeyCode.Q },
        {ActionEnum.SkillKeyCode2, KeyCode.W },

        {ActionEnum.Sure, KeyCode.Mouse0 },
        {ActionEnum.Move, KeyCode.Mouse1 },
    };

    Dictionary<ActionEnum, Action<Vector2>> actionMap = new Dictionary<ActionEnum, Action<Vector2>>();

    Queue<InputCmd> queue = new Queue<InputCmd>();

    private void Update()
    {
        //TODO: 处理连按情况
        foreach (var mapItem in inputMap)
        {
            if (Input.GetKeyUp(mapItem.Value))
            {
                queue.Enqueue(new InputCmd() { actionEnum = mapItem.Key, mousePosition = Input.mousePosition, time = Time.realtimeSinceStartup });
                Debug.Log(mapItem.Key + " - " + Input.mousePosition);
                if (actionMap.ContainsKey(mapItem.Key))
                    actionMap[mapItem.Key](Input.mousePosition);
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

    public void AddListener(ActionEnum actionEnum, Action<Vector2> action)
    {
        actionMap[actionEnum] = action;
    }
}
