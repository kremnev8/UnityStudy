using System;
using Model;
using Platformer.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Study.Scripts
{
    public class Task6Class1 : MonoBehaviour
    {
        private PlayerInput _input;
        private InputAction rAction;

        private Rigidbody body;

        private void Start()
        {
            _input = Simulation.GetModel<GameModel>().input;
            rAction = _input.actions["rUse"];
            rAction.performed += OnPressed;

            body = GetComponent<Rigidbody>();
        }

        private void OnPressed(InputAction.CallbackContext obj)
        {
            body.AddForce(0,200,0);
        }
    }
}