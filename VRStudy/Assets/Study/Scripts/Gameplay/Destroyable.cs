using UnityEngine;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Units
{
    public class Destroyable : MonoBehaviour
    {
        private Health health;
        [FormerlySerializedAs("Death")] public UnityEvent death;
        protected virtual void Awake()
        {
            health = GetComponent<Health>();
            if (health != null)
                health.isZero.AddListener(Die);
        }

        public void Die()
        {
            death?.Invoke();
            Destroy(gameObject, 0.1f);
        }
    }
}