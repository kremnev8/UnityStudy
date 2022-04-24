using System;
using UnityEngine;
using UnityEngine.Events;
using Util;

namespace World
{
    public class TriggerGeneric : MonoBehaviour
    {
        public UnityEvent onEnter;
        public UnityEvent onExit;

        public bool useTriggers = false;
        public bool onlyPlayer = false;
        public bool onlyGhost = false;

        public bool onlyCustomTag = false;
        [TagSelector]
        public string customTag;
        
        
        public bool onlyOnce = false;
        private bool wasTriggered;

        private void OnTriggerEnter(Collider other)
        {
            if (onlyOnce && wasTriggered) return;
            if (other.isTrigger && !useTriggers) return;
            if (onlyPlayer && !other.gameObject.CompareTag("Player")) return;
            if (onlyGhost && !other.gameObject.CompareTag("Ghost")) return;
            if (onlyCustomTag && !other.gameObject.CompareTag(customTag)) return;
            
            if (other.CompareTag("NoPhysics")) return;
            
            onEnter?.Invoke();
            wasTriggered = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (onlyOnce && wasTriggered) return;
            if (other.isTrigger && !useTriggers) return;
            if (onlyPlayer && !other.gameObject.CompareTag("Player")) return;
            if (onlyGhost && !other.gameObject.CompareTag("Ghost")) return;
            if (onlyCustomTag && !other.gameObject.CompareTag(customTag)) return;
            
            onExit?.Invoke();
            wasTriggered = true;
        }
    }
}