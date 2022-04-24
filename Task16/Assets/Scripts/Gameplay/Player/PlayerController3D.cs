using Model;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Gameplay
{
    public class PlayerController3D : CharacterController3D
    {
        protected override void Start()
        {
            config = GetModel<GameModel>().config;
            
            base.Start();
        }
    }
}