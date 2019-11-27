using UnityEngine;

namespace Assets.Scripts.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        public abstract int AttackDamage { get; set; }
    }
}