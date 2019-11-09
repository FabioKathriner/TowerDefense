using UnityEngine;

namespace Assets.Scripts
{
    public class Cannon : MonoBehaviour, IWeapon
    {
        [SerializeField]
        private GameObject _projectilePrefab;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void Fire(GameObject target)
        {
            transform.LookAt(target.transform);
            var projectile = Instantiate(_projectilePrefab, transform.position + Vector3.forward * 0.5f, transform.rotation);
            var script = projectile.GetComponent<SeekingMissile>();
            if (script != null)
                script.Target = target;
        }
    }
}
