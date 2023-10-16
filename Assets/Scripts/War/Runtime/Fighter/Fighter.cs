using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace War
{
    public class Fighter : Role
    {
        [SerializeField]
        private SkillComponent skillCom = new SkillComponent();
        public SkillComponent SkillCom { get => skillCom; }

        [SerializeField]
        private Property propCom = new Property();
        public Property PropCom { get => propCom; }

        private Fighter owner;
        public Fighter Owner
        {
            get => owner;
            set => owner = value;
        }

        public void Awake()
        {
            skillCom.Init(this);
        }

        public void Update()
        {
            if (Input.GetKeyUp(KeyCode.Q) && isMainActor)
            {
                SkillCom.Play(1);
            }
        }

        public bool TempMoveTo(Vector3 destination, MoveType moveType, float speed, Action<bool> action)
        {
            this.gameObject.transform.localPosition = destination;
            action?.Invoke(true);
            return true;
            //throw new NotImplementedException();
        }

        public event Action<HitResult> onHit;

        public void TempHit()
        {
            onHit?.Invoke(new HitResult(this, null, Vector3.zero, HitResult.Result.Success));
        }

        protected void Hit(HitResult result)
        {
            onHit?.Invoke(result);
        }
    }
}