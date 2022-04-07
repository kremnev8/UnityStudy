using System;
using UnityEngine;

namespace Gameplay.World
{
    public class HideInEditor : Terminator
    {
        protected override void Start()
        {
            if (Application.isEditor)
            {
                base.Start();
            }
        }
    }
}