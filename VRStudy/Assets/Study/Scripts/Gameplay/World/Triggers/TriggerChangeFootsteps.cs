using System;
using Sound;
using UnityEngine;

namespace Sound
{
    public class TriggerChangeFootsteps : MonoBehaviour
    {
        //public SoundController controller;
        public AudioClip[] newSounds;

        private bool done;
        public bool tryFind;
        public string searchName;

        private void Start()
        {
            if (tryFind)
            {
               // controller = GameObject.Find(searchName).GetComponent<SoundController>();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!done)
            {
               // controller.sounds = newSounds;
                done = true;
            }
        }
    }
}