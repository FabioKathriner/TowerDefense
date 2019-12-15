using Assets.Scripts.Health;

namespace Assets.Scripts.Towers
{
    public interface ITower : IUnit
    {
        string Name { get; }
        int Level { get; set; }
    }
}