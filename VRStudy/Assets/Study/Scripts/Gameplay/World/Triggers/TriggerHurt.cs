using System.Collections.Generic;
using Units;
using UnityEngine;
using UnityEngine.Events;

namespace World
{
    public class TriggerHurt : MonoBehaviour
    {
        public int damage = 1;
        public int damageInterval = 60;
        private int tickCount;

        public PainType painType = PainType.Physical;

        private List<Health> inside = new List<Health>();

        public UnityEvent onHurt;


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("NoPhysics")) return;
            if (other.gameObject.TryGetComponent(out Health health))
            {
                inside.Add(health);
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("NoPhysics")) return;
            if (other.gameObject.TryGetComponent(out Health health))
            {
                if (inside.Contains(health))
                {
                    inside.Remove(health);
                }
            }
        }

        

        private void Update()
        {
            tickCount++;
            if (tickCount < damageInterval) return;

            tickCount = 0;

            foreach (Health health in inside)
            {
                health.Decrement(damage, painType);
                onHurt?.Invoke();
            }
        }
    }
}