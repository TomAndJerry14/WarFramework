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
                    buffCom.OnBuffTick += OnBuffTick;
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

        public void Start()
        {

        }

        void OnBuffTick(BuffData data)
        {
            switch (data.type)
            {
                case BuffType.ModifyAttriBute:
                    OnAttributeChanged(data.attribute, data.value);
                    break;
                default: 
                    return;
            }
        }

        void OnAttributeChanged(AttributeType attribute, float value)
        {
            this.AttrCom[attribute] += value;
            Debug.Log($"type: {attribute}   value:{this.AttrCom[attribute]}");
        }

        void OnCantSelectBuffTick()
        {

        }

        public void Update()
        {
            if (Input.GetKeyUp(KeyCode.Q) && isMainActor)
            {
                SkillCom.Play(1);
            }

            BuffCom.Tick(Time.deltaTime);
        }

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
            //throw new NotImplementedException();
        }
    }
}