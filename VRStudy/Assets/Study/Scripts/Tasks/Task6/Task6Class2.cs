using System;
using UnityEngine;

namespace Study.Scripts
{
    public class Task6Class2 : MonoBehaviour
    {
        protected Renderer renderer;

        protected void Start()
        {
            renderer = GetComponent<Renderer>();
        }

        public void ChangeColor()
        {
            renderer.material.color = Color.red;
        }
    }
}