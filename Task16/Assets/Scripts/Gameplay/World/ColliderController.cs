using System;
using UnityEngine;

namespace World
{
    public class ColliderController : MonoBehaviour
    {
        private Collider myCollider;
        private Rigidbody body;
        public float threshold = 5f;
        
        private void Awake()
        {
            myCollider = GetComponent<Collider>();
            body = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (body.velocity.magnitude > threshold)
            {
                if (!myCollider.enabled)
                    myCollider.enabled = true;
            }else
            {
                if (myCollider.enabled)
                    myCollider.enabled = false;
            }
        }
    }
}