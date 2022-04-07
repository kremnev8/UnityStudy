using System;
using Units;
using UnityEngine;

namespace World
{
    public class TriggerHurtOnce : MonoBehaviour
    {
        public int damage = 1;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("NoPhysics")) return;
            if (other.gameObject.TryGetComponent(out Health health))
            {
                health.Decrement(damage);
            }
        }
    }
}