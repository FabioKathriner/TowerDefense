using UnityEngine;

namespace Assets.Scripts
{
    public class Projectile : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Destroy(gameObject, 5f);
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        void OnCollisionEnter(Collision collision)
        {
            Destroy(gameObject);
        }
    }
}
