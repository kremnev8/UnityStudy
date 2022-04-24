using Model;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;
using Util;
using static Platformer.Core.Simulation;

namespace Gameplay
{
    public class Player3DWalkModule : ControllerModule
    {
        private InputAction moveAction;
        private InputAction runAction;

        private Vector2 currentDir = Vector2.zero;
        private Vector3 velocity;
        private Vector2 currentDirVelocity = Vector2.zero;

        public bool canRun = true;

        public float minDistance = 2;


        protected override void OnInit()
        {
            GameModel model = GetModel<GameModel>();
            moveAction = model.input.actions["move"];
            runAction = model.input.actions["run"];
        }

        protected override void OnUpdateModule()
        {
            float maxSpeed = (config as PlayerSettings).runningMaxSpeed;
            if (canRun && runAction.IsPressed())
            {
                maxSpeed = config.normalMaxSpeed;
            }

            Vector2 targetDir = Vector2.zero;
            if (controller.controlEnabled)
            {
                targetDir = moveAction.ReadValue<Vector2>().normalized * maxSpeed;
            }

            float smoothTime = controller.onGround ? config.moveSmoothTime : config.airMoveSmoothTime;
            
            currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, smoothTime);

            velocity = (transform.forward * currentDir.y + transform.right * currentDir.x);// + Vector3.up * velocityY;

            controller.SetVelocity(controller.GetVelocity() * config.friction);
            
            //_controller3D._body.MovePosition(controller.GetPosition() +  velocity * Time.deltaTime);

            if (velocity.magnitude > 0.01f)
            {
                controller.AddVelocity(velocity);
            }
            
            controller.SetVelocity(controller.GetVelocity().ClampHorizontal(maxSpeed));
        }
    }
}