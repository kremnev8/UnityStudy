using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.World
{
    public class LogicDelay : MonoBehaviour
    {
        public UnityEvent timeEnded;
        public float timeout = 60f;
        public bool disabled = false;

        public void SetDisabled(bool newState)
        {
            disabled = newState;
        }
        
        public void Trigger()
        {
            Invoke(nameof(TriggerLater), timeout);
        }

        private void TriggerLater()
        {
            if (!disabled)
                timeEnded.Invoke();
        }
    }
}