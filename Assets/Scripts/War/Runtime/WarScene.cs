﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using War;

public class WarScene : MonoBehaviour
{
    public static WarScene Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Main();
    }

    internal Fighter[] GetAllFighter()
    {
        return fighters;
    }

    public WarReferees referees = new WarReferees();

    GameObject go1;
    Fighter mainActor;
    GameObject go2;
    Fighter mainActorFriend;
    GameObject go3;
    Fighter enemy;

    Fighter[] fighters;

    SkillBase skill;
    GameObject guide;
    GameObject guideOfMouse;
    public void Main()
    {
        guide = GameObject.Find("Guide");
        guideOfMouse = GameObject.Find("guideOfMouse");

        go1 = GameObject.Find("Player");
        mainActor = go1.GetComponent<Fighter>();

        //go2 = GameObject.Find("Friend");
        //mainActorFriend = go2.GetComponent<Fighter>();

        //go3 = GameObject.Find("Enemy");
        //enemy = go3.GetComponent<Fighter>();

        //fighters = new Fighter[] { mainActor, mainActorFriend, enemy };

        //skill = SkillFactroy.CreateSkill(2, mainActor, Vector2.zero, null);

        //Test();

        Buff.BuffData data = new Buff.BuffData()
        {
            id = 1,
            buffName = "1",
            maxStack = 1,
            priority = 1,
            stackable = true,
            tags = new Buff.BuffTag[] { Buff.BuffTag.CantMove, Buff.BuffTag.CantAttck },
            durationTime = 5f,
            deltaTime = 0.5f,
            isIncremental = true,
            type = Buff.BuffType.ModifyAttriBute,

            value = -10,
        };

        var buffCom = mainActor.BuffCom;
        buffCom.Add(data);
        Debug.Log("War Scene");
    }

    public void Test()
    {
        InputManager.Instance.AddListener(ActionEnum.SkillKeyCode1, (position) =>
        {
            UseSkill = true;
        });

        InputManager.Instance.AddListener(ActionEnum.SkillKeyCode2, (position) =>
        {
            UseSkill = true;
        });

        InputManager.Instance.AddListener(ActionEnum.Move, (position) =>
        {

            if (UseSkill)
            {
                UseSkill = false;
                return;
            }
            Debug.Log($"Mouse Position: {position} WorldPos: {Camera.main.ScreenToWorldPoint(position)}");
            var ray = Camera.main.ScreenPointToRay(position);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.blue);
            Physics.Raycast(ray, out var hitInfo, 100, LayerMask.GetMask("Plane"));


            mainActor.TempMoveTo(hitInfo.point, MoveType.FixedSpeed, 1, () =>
            {
            });
        });


        InputManager.Instance.AddListener(ActionEnum.Sure, (position) =>
        {
            if (UseSkill)
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Debug.DrawRay(ray.origin, ray.direction * 100, Color.blue);
                Physics.Raycast(ray, out var hitInfo, 100, LayerMask.GetMask("Plane"));

                UseSkill = false;
                skill = SkillFactroy.CreateSkill(2, mainActor, new Vector2(hitInfo.point.x, hitInfo.point.z), null);
                referees.InsertSkill(skill);
            }
        });
    }

    bool useSkill = false;
    bool UseSkill
    {
        get
        {
            return useSkill;
        }
        set
        {
            guideOfMouse.SetActive(value);
            guide.SetActive(value);
            useSkill = value;
        }
    }
    float rangeScale = 0.1f;
    private void OnDrawGizmos()
    {
        if (UseSkill)
        {
            //把圆圈限制在技能范围内
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.blue);
            Physics.Raycast(ray, out var hitInfo, 100, LayerMask.GetMask("Plane"));
            guideOfMouse.transform.position = new Vector3(hitInfo.point.x, 0.15f, hitInfo.point.z);

            var scaleOfMouse = skill.data.useSkillRange.areaData.circle.range * rangeScale;
            guideOfMouse.transform.localScale = new Vector3(scaleOfMouse, scaleOfMouse, scaleOfMouse);
            var scaleOfUseSkill = skill.data.useSkillRange.range * rangeScale;
            guide.transform.localScale = new Vector3(scaleOfUseSkill, scaleOfUseSkill, scaleOfUseSkill);
        }
    }


    void Update()
    {
        referees.Tick();
    }
}