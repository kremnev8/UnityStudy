using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.World.Logic
{
    public class LogicRelay : MonoBehaviour
    {
        public UnityEvent activated;
        public bool onlyOnce;

        private bool wasActivated;
        
        public void Activate()
        {
            if (onlyOnce && wasActivated) return;
            
            activated.Invoke();
            wasActivated = true;
        }
        
    }
}