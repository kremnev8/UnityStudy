using Model;
using Platformer.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class TPCameraController : MonoBehaviour
    {
        public Transform lookAt;

        private float currentX = 70;
        private float currentY = 40;
        public float sensitivity = 0.4f;

        private PlayerSettings config;

        private PlayerInput input;
        private InputAction lookAction;
        private InputAction lookActivateAction;
        private InputAction scrollAction;
        
        private bool isMouseDown = false;

        private float currentDistance;


        private void Start()
        {
            GameModel model = Simulation.GetModel<GameModel>();
            config = model.config;
            input = model.input;
            
            lookAction = input.actions["look"];
            lookActivateAction = input.actions["lookActivate"];
            scrollAction = input.actions["mouseScroll"];

            currentY = Mathf.Clamp(currentY, config.yAngleMin, config.yAngleMax);
            currentDistance = config.cameraDistance;

            lookActivateAction.started += OnDown;
            lookActivateAction.canceled += OnUp;
        }

        private void OnDown(InputAction.CallbackContext ctx)
        {
            isMouseDown = true;
        }

        private void OnUp(InputAction.CallbackContext ctx)
        {
            isMouseDown = false;
        }

        private void CheckChanges() { }

        private void Update()
        {
            float mouseScroll = scrollAction.ReadValue<Vector2>().y / config.cameraScrollSensitivity;
            currentDistance += mouseScroll * Time.deltaTime;
            currentDistance = Mathf.Clamp(currentDistance, config.minCameraDistance, config.cameraDistance);

            if (!isMouseDown) return;

            Vector2 look = lookAction.ReadValue<Vector2>() * config.sensitivity * sensitivity;


            currentX += look.x;
            currentY += look.y;

            currentY = Mathf.Clamp(currentY, config.yAngleMin, config.yAngleMax);
        }

        private void LateUpdate()
        {
            Vector3 dir = new Vector3(0, 0, -currentDistance);
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            var position = lookAt.position + config.cameraOffset;

            /*bool hitSomething = Physics.Raycast(position, rotation*Vector3.back, out RaycastHit hit,  currentDistance, mask);
    
            if (hitSomething)
            {
                dir = new Vector3(0, 0, -hit.distance + config.collisionOffset);
            }*/

            transform.position = position + rotation * dir;

            transform.LookAt(position);
        }
    }
}