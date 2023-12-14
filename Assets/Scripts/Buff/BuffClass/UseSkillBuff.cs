using Debug = UnityEngine.Debug;

namespace Buff
{
    public class UseSkillBuff : BuffBase
    {
        public override BuffEnum registerType => BuffEnum.UseSkill;

        protected override void OnEnter()
        {
            base.OnEnter();

            Debug.Log("UseSkillBuff OnEnter");
        }

        protected override void OnTick(float time)
        {
            base.OnTick(time);

            Debug.Log("UseSkillBuff OnTick");

        }

        protected override void OnExit()
        {
            base.OnExit();

            Debug.Log("UseSkillBuff OnExit");

        }

        public override void SendEvent(RoleEvent roleEvent)
        {
            base.SendEvent(roleEvent);

            if (roleEvent == RoleEvent.Attack)
            {
                Excute();
            }
            if (data.existType == BuffExistType.NextAttack)
            {
                Exit();
            }
        }

        protected override void OnExcute()
        {
            Exit();
        }
    }
}
