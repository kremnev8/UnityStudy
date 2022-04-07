using System;
using Units;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.World.Logic
{
    public class PainSwitch : MonoBehaviour
    {
        public UnityEvent[] events = new UnityEvent[2];

        public void Activate()
        {
            Activate(PainType.Physical);
        }

        public void Activate( PainType input)
        {
            switch (input)
            {
                case PainType.Physical:
                    events[0]?.Invoke();
                    break;
                case PainType.Mental:
                    events[1]?.Invoke();
                    break;
            }
        }
        
    }
}