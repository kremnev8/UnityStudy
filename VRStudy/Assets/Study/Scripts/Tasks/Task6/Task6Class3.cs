using System;
using UnityEngine;

namespace Study.Scripts
{
    public class Task6Class3 : Task6Class2
    {
        public bool hover;
        
        public void Green()
        {
            renderer.material.color = Color.green;
            hover = true;
        }   

        public void Blue()  
        {
            renderer.material.color = Color.blue;
            hover = false;
        }
    }
}