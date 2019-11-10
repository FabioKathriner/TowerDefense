
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField]
        protected float Speed = 10f;

        [SerializeField]
        protected int Damage = 10;

        public GameObject Target { get; set; }

        // Start is called before the first frame update
        protected virtual void Start()
        {
            Destroy(gameObject, 5f);
        }
    }
}