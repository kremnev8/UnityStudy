using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Gameplay.World.Triggers
{
    public class TriggerIncreaseVolume : MonoBehaviour
    {
        public AudioSource source;
        public float newVolume;

        public bool tryFind;

        private void Start()
        {
            if (tryFind)
            {
                source = GameObject.Find("MainObjects").GetComponent<AudioSource>();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                source.volume = newVolume;
            }
        }
    }
}