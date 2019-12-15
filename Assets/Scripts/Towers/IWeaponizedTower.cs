using Assets.Scripts.Weapons;

namespace Assets.Scripts.Towers
{
    public interface IWeaponizedTower : ITower
    {
        Weapon GetWeapon();
        float RateOfFire { get; }
    }
}