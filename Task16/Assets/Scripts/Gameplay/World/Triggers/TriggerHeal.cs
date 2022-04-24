using Units;
using UnityEngine;

namespace Gameplay.World.Triggers
{
    public class TriggerHeal : MonoBehaviour
    {
        public int healing = 4;
        public bool onlyOnce = true;
        private bool used;

        private void OnTriggerEnter(Collider other)
        {
            if (onlyOnce && used) return;
            if (other.CompareTag("NoPhysics")) return;
            if (other.gameObject.TryGetComponent(out Health health))
            {
                used = true;
                health.Increment(healing);
            }
        }
    }
}