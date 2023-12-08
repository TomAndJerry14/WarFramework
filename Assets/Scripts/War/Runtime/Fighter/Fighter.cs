using Buff;
using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace War
{
    public class Fighter : Role, IReceiveHit, ISendHit
    {
        [SerializeField]
        private SkillComponent skillCom = new SkillComponent();
        public SkillComponent SkillCom { get => skillCom; }

        [SerializeField]
        private AttributeCom attrCom = new AttributeCom();
        public AttributeCom AttrCom { get => attrCom; }



        public StateCtrl StateCtrl { get; set; }

        private Fighter owner;
        public Fighter Owner
        {
            get => owner;
            set => owner = value;
        }

        private BuffComponent buffCom;
        public BuffComponent BuffCom
        {
            get
            {
                if (buffCom == null)
                {
                    buffCom = new BuffComponent();
                    buffCom.OnBuffExcute += OnBuffExcute;
                }
                return buffCom;
            }
        }

        public FighterTeamEnum teamEnum;

        public void Awake()
        {
            skillCom.Init(this);
            StateCtrl = new StateCtrl();
        }

        void OnBuffExcute(BuffData data)
        {
            Debug.Log("OnBuffExcute");
            if (data.type == BuffType.AttriBute)
            {
                OnBuffTick(data);
            }
            else if (data.type == BuffType.Event)
            {
                skillCom.UseSkill((int)data.value);
                Debug.Log($" skillCom.UseSkill{((int)data.value)}");
            }
        }

        private void OnBuffTick(BuffData data)
        {
            switch (data.modifyType)
            {
                case ModifyType.Change:
                    this.AttrCom[data.attribute] = data.value;
                    OnAttributeChanged(data.attribute);
                    break;
                case ModifyType.Quantify:
                    this.AttrCom[data.attribute] = data.value;
                    OnAttributeChanged(data.attribute);
                    break;
                case ModifyType.Increment:
                    this.AttrCom[data.attribute] += data.value;
                    OnAttributeChanged(data.attribute);
                    break;
                default:
                    break;
            }

        }

        void OnAttributeChanged(AttributeType attribute)
        {
            Debug.Log($"type: {attribute}   value:{this.AttrCom[attribute]}");
        }

        public void Update()
        {
            if (Input.GetKeyUp(KeyCode.Q) && isMainActor)
            {
                SkillCom.Play(1);
            }
        }

        public void WarTick(int frame)
        {
            BuffCom.Tick(frame * WarReferees.oneFrameTime);
        }


        #region 废弃
        //TODO 封装移动组件
        Vector3? Destination = null;
        public async void TempMoveTo(Vector3 destination, MoveType moveType, float speed, Action action)
        {
            /*TODO 
             * moveType
             * 
             */

            Debug.Log($"TempMoveTo name:{this.gameObject.name}  destination:{destination}");

            if (Destination.HasValue)
            {
                Destination = destination;
                return;
            }

            Destination = destination;


            await UniTask.WaitUntil(CheckMoveStop);


            this.gameObject.transform.localPosition = Destination.Value;
            Destination = null;

            action?.Invoke();
        }

        bool CheckMoveStop()
        {
            if (Destination.HasValue)
            {
                this.gameObject.transform.position += (Destination.Value - this.gameObject.transform.position).normalized * 100 * Time.deltaTime;
                return Vector2.Distance(this.gameObject.transform.position, Destination.Value) <= 0.5f;
            }
            return false;
        }

        public event Action<HitResult> onHit;

        public void TempHit()
        {
            onHit?.Invoke(new HitResult(this, null, Vector3.zero, HitResult.Result.Success));
        }
        public void OnHit(HitResult result)
        {
            onHit?.Invoke(result);
        }

        public void Hit(HitResult result)
        {
            result.Receiver.OnHit(result);
        }

        public void Attack()
        {
            BuffBase[] buffs = buffCom.GetBuffs(BuffTag.CantAttck);
            if (buffs.Length > 0)
            {
                Debug.LogError("缴械");
                return;
            }

            //buffs = buffCom.GetBuffs(BuffTag.UseSkill);
            //for (int i = 0; i < buffs.Length; i++)
            //{
            //    var buff = buffs[i];
            //    buff.Excute();
            //}

            buffCom.SendEvent(RoleEvent.Attack);

        }

        #endregion

    }
}