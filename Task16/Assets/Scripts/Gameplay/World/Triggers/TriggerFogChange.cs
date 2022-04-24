using System;
using UnityEngine;

namespace World
{
    public class TriggerFogChange : MonoBehaviour
    {
        public float newDensity = 0.2f;
        public Color newColor = Color.white;
        private bool didTrigger;
        private void OnTriggerEnter(Collider other)
        {
            if (!didTrigger && other.CompareTag("Player"))
            {
                didTrigger = true;
                RenderSettings.fogDensity = newDensity;
                RenderSettings.fogColor = newColor;
            }
        }
    }
}