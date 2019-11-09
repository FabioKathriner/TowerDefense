namespace Assets.Scripts
{
    public interface IHealth
    {
        int CurrentHealth { get; set; }
        int MaxHealth { get; set; }
        void TakeDamage(int damage);
    }
}