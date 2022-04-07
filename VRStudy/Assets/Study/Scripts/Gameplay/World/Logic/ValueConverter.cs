using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.World.Logic
{
    public class ValueConverter : MonoBehaviour
    {
        public UnityEvent<float> output;

        public void Input(int value)
        {
            output?.Invoke(value);
        }
    }
}