namespace Buff
{
    public interface IBuffComponent
    {
        public void Add(BuffData data);
        public void Tick(float tickDeltaTime);

        public void SetInValid(BuffData data);
        public void Remove(BuffData data);

        public void SendEvent(RoleEvent roleEvent);

        public BuffBase[] GetBuffs(BuffTag tag);

        public BuffBase[] GetBuffs(BuffExistType type, BuffTag tag);

        public void Clear();
    }
}
