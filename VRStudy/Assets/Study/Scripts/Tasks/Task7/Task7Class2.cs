using UnityEngine;

namespace Study.Scripts.Task7
{
    public class Task7Class2 : MonoBehaviour
    {
        private Rigidbody body;
        
        public float speed;

        private void Awake()
        {
            body = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            Vector3 vel = transform.forward * speed;
            vel.y = body.velocity.y;
            body.velocity = vel;    
        }
    }
}