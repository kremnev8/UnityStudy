using System;
using Model;
using Platformer.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Study.Scripts.Task8
{
    public class Task8Class1 : MonoBehaviour
    {
        private Animator animator;
        private PlayerInput _input;
        private InputAction rAction;
        private static readonly int Jump = Animator.StringToHash("Jump");


        private void Start()
        {
            animator = GetComponent<Animator>();
            _input = Simulation.GetModel<GameModel>().input;
            rAction = _input.actions["use"];
            rAction.performed += OnPressed;
        }

        private void OnPressed(InputAction.CallbackContext obj)
        {
            animator.SetTrigger(Jump);
        }
    }
}