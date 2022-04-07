using System;
using Model;
using Platformer.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Study.Scripts.Task7
{
    public class Task7Class3 : MonoBehaviour
    {
        private PlayerInput _input;
        private InputAction rAction;

        public GameObject prefab;
        
        private void Start()
        {
            _input = Simulation.GetModel<GameModel>().input;
            rAction = _input.actions["rUse"];
            rAction.performed += OnPressed;
        }

        private void OnPressed(InputAction.CallbackContext obj)
        {
            Instantiate(prefab, transform.position, transform.rotation);
        }
    }
}