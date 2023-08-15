using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace War
{
    public enum HitResult
    {
        Success,
        Fail,
        zhimang,//ÖÂÃ¤
    }

    public class Fighter : MonoBehaviour
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


        public bool TempMoveTo(Vector3 destination, MoveType moveType, float speed, Action<bool> action)
        {
            this.gameObject.transform.localPosition = destination;
            action?.Invoke(true);
            return true;
            //throw new NotImplementedException();
        }

        public event Action<Fighter, Fighter, HitResult> onHit;

        public void TempHit()
        {
            onHit?.Invoke(this, null, HitResult.Success);
        }
    }
}