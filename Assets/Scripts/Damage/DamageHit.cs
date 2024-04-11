namespace Game
{
    public interface IDamageHit
    {
        public void Kill();
    }

    public interface IDamageHit<T> : IDamageHit
    {
        public void Damage(T attack);
        public void Kill(T attack);
    }

    public abstract class DamageHit<T> : IDamageHit<T>
    {
        public virtual void Damage(T attack) { }
        public void Kill(T attack) { }
        public virtual void Kill() { }
    }
}