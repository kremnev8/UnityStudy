using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Platformer.Core.Simulation;
using Model;

namespace Player
{

    public class FPCameraController : MonoBehaviour
    {
        private PlayerSettings config;

        public float currentX = 0.0f;
        public float currentY = 0.0f;

        private GameModel model;
        private Transform player;

        private InputAction lookAction;
    
        public static bool isEnabled = true;

        private void Awake()
        {
            LockCursor(true);
        }

        private void Start()
        {
            model = GetModel<GameModel>();
            PlayerInput input = model.input;
            config = model.config;
            player = model.player.transform;
        
            lookAction = input.actions["look"];
            currentY = Mathf.Clamp(currentY, config.yAngleMin, config.yAngleMax);
        }

        public static void LockCursor(bool newState)
        {
            Cursor.lockState =  newState ? CursorLockMode.Locked : CursorLockMode.None;
        }

        private void Update()
        {
            if (!isEnabled) return;
            if (!model.player.controlEnabled) return;
        
            Vector2 look = lookAction.ReadValue<Vector2>() * config.sensitivity * Time.deltaTime;
            currentX += look.x;
            currentY += look.y;

            currentY = Mathf.Clamp(currentY, config.yAngleMin, config.yAngleMax);
        
            transform.localRotation = Quaternion.Euler(currentY, 0, 0);
            player.rotation = Quaternion.Euler(0, currentX, 0);
        }
    }
    
}