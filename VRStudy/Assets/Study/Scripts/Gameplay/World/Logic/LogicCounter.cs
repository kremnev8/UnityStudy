using System;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.World
{
    public class LogicCounter : MonoBehaviour
    {
        public int minCount = 0;
        public int maxCount = 2;
        private int current;

        public UnityEvent hitMax;
        public UnityEvent hitMin;
        
        private void Awake()
        {
            Reset();
        }

        public void Increment()
        {
            current++;
            if (current >= maxCount)
            {
                current = maxCount;
                hitMax?.Invoke();
            }
        }

        public void Decrement()
        {
            current--;
            if (current <= minCount)
            {
                current = minCount;
                hitMin?.Invoke();
            }
        }

        public void Reset()
        {
            current = minCount;
        }
    }
}