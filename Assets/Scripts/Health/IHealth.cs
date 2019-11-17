namespace Assets.Scripts.Health
{
    public interface IHealth
    {
        int CurrentHealth { get; set; }
        int MaxHealth { get; set; }
        void TakeDamage(int damage);
        void Die();
    }
}