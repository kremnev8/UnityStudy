using System;
using UnityEngine;

namespace Study.Scripts
{
    public class Task9Class : MonoBehaviour
    {
        private AudioSource _source;


        private void Awake()
        {
            _source = GetComponent<AudioSource>();
        }

        private void OnCollisionEnter(Collision other)
        {
            _source.Play();
        }
    }
}