namespace Assets.Scripts.Towers
{
    public interface ITower
    {
        string Name { get; }
        int Level { get; set; }
        Health.Health Health { get; }
    }
}