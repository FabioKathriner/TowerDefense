namespace Assets.Scripts.Weapons
{
    // TODO: Swap ISimpleWeapon and IWeapon?
    public interface ISimpleWeapon : IWeapon
    {
        void Fire();
    }
}