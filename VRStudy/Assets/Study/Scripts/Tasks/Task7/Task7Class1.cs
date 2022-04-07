using System;
using UnityEngine;

namespace Study.Scripts.Task7
{
    public class Task7Class1 : MonoBehaviour
    {
        public float speed;

        private void Update()
        {
            transform.Translate(Time.deltaTime * transform.forward * speed, Space.World);
        }
    }
}