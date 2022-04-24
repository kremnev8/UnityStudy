using System;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.World
{
    public class LogicAuto : MonoBehaviour
    {
        public UnityEvent mapLoad;
        
        private void Start()
        {
            mapLoad.Invoke();
        }
    }
}