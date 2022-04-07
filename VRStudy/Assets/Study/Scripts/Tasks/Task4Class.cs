using System;
using UnityEngine;

namespace Study.Scripts
{
    public class Task4Class : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Box")) return;
            
            Destroy(other.gameObject);
        }
    }
}