using Model;
using Platformer.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Study.Scripts
{
    public class Task6Class4 : Task6Class3
    {
        private PlayerInput _input;
        private InputAction mouseDown;
        
        private Rigidbody body;

        private void Start()
        {
            base.Start();
            _input = Simulation.GetModel<GameModel>().input;
            mouseDown = _input.actions["mouseDown"];
            mouseDown.performed += OnPressed;

            body = GetComponent<Rigidbody>();

        }

        private void OnPressed(InputAction.CallbackContext obj)
        {
            if (hover)
            {
                Debug.Log(gameObject.name + " pos: " + body.position);
            }
        }
    }
}