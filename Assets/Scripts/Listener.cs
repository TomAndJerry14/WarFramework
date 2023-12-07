using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using War;

public class Listener : MonoBehaviour
{
    public WarScene WarScene;

    public InputField inputField;

    public Button skill1Btn;
    public Button skill2Btn;

    // Start is called before the first frame update
    void Start()
    {
        inputField.onValueChanged.AddListener(Test);

        var skill1Icon = skill1Btn.GetComponent<Image>();
        skill1Btn.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {

        }));
        var skill2Icon = skill1Btn.GetComponent<Image>();
        skill2Btn.onClick.AddListener(new UnityEngine.Events.UnityAction(() =>
        {

        }));
    }

    void Test(string endInput)
    {
        GameObject go1 = GameObject.Find("Player");
        Fighter mainActor = go1.GetComponent<Fighter>();
        var _enum = (StateEnum)int.Parse(endInput);
        Debug.Log(_enum);
        switch (_enum)
        {
            case StateEnum.Idle:
                mainActor.StateCtrl.Switch(new IdleState());
                break;
            case StateEnum.Walk:
                //mainActor.StateCtrl.Switch(new IdleState());
                Debug.LogError("skip");
                break;
            case StateEnum.Skill:
                mainActor.StateCtrl.Switch(new SkillState());
                break;
            case StateEnum.Test1:
                mainActor.StateCtrl.Switch(new Test1State());
                break;
            case StateEnum.Test2:
                mainActor.StateCtrl.Switch(new Test2State());
                break;
            case StateEnum.Test3:
                mainActor.StateCtrl.Switch(new Test3State());
                break;
            case StateEnum.Test4:
                mainActor.StateCtrl.Switch(new Test4State());
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
