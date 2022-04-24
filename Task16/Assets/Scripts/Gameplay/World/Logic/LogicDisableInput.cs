using Model;
using Platformer.Core;
using UnityEngine;

namespace Gameplay.World.Logic
{
    public class LogicDisableInput : MonoBehaviour
    {
        private GameModel model;

        private void Start()
        {
            model = Simulation.GetModel<GameModel>();
        }

        public void SetControlEnabled(bool newState)
        {
            model.player.controlEnabled = newState;
        }
    }
}