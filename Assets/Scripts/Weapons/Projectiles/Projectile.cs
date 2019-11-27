
using UnityEngine;

namespace Assets.Scripts.Weapons.Projectiles
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField]
        protected float Speed = 10f;

        [SerializeField]
        private int _damage = 10;

        public GameObject Target { get; set; }

        public int Damage
        {
            get => _damage;
            set => _damage = value;
        }

        // Start is called before the first frame update
        protected virtual void Start()
        {
            Destroy(gameObject, 5f);
        }
    }
}