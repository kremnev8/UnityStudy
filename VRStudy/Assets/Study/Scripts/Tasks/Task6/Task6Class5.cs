using System;
using Model;
using Platformer.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Study.Scripts
{
    public class Task6Class5 : Task6Class3
    {
        private PlayerInput _input;
        private InputAction mouseDown;

        private Rigidbody body;
        private Camera main;

        public Vector3 offset;

        private void Start()
        {
            base.Start();
            _input = Simulation.GetModel<GameModel>().input;
            mouseDown = _input.actions["mouseDown"];

            body = GetComponent<Rigidbody>();
            main = Camera.main;

        }

        private void Update()
        {
            if (hover && mouseDown.IsPressed())
            {
                Vector3 position = main.ScreenToWorldPoint(new Vector3(main.pixelWidth / 2f,main.pixelHeight / 2f, main.nearClipPlane));
                Debug.Log(position);
                body.MovePosition(position + offset);
            }
            
        }
    }
}