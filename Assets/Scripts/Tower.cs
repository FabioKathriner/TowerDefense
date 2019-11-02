using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Tower : MonoBehaviour, IHealth, IDamagable, IUpgradable
    {
        public int CurrentHealth { get; set; }
        public int MaxHealth { get; set; }
        public IWeapon Weapon { get; set; }

        public int Level { get; set; }
        public abstract void Upgrade();
    }
}