namespace Buff
{
    public class ModifyAttributeBuff : BuffBase
    {
        public override BuffEnum registerType => BuffEnum.ModifyAttribute;

        protected override void OnEnter()
        {
            if (data.modifyType == ModifyType.Quantify || data.modifyType == ModifyType.Change)
                Excute();
        }

        protected override void OnTick(float time)
        {
            base.OnTick(time);

            if (data.modifyType == ModifyType.Increment)
                Excute();
        }

        protected override void OnTimeHandleInValid()
        {
            base.OnTimeHandleInValid();
            Exit();
        }
    }
}
