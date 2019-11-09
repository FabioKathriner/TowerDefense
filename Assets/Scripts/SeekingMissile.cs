using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class SeekingMissile : MonoBehaviour
    {
        [SerializeField]
        private readonly float _speed = 5f;

        [SerializeField]
        private int _damage = 10;


        public GameObject Target { get; set; }

        // Start is called before the first frame update
        private void Start()
        {
            Destroy(gameObject, 5f);
        }

        // Update is called once per frame
        private void Update()
        {
        }

        private void FixedUpdate()
        {
            if (Target != null)
                transform.LookAt(Target.transform);

            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            var health = collision.gameObject.GetComponent<Health>();
            health.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}