using UnityEngine;

namespace Gameplay.World.Logic
{
    public class DoorRotational : MonoBehaviour
    {
        private Rigidbody body;
        private float timeElapsed;
        private Quaternion initialRotation;
        
        public float closedAngle;
        public float openAngle;
        public Vector3 axis = Vector3.up;
        
        public float moveTime;

        private bool isOpen;
        private bool flipDirection;
        
        private void Awake()
        {
            body = GetComponent<Rigidbody>();
            initialRotation = body.rotation;
            timeElapsed = moveTime;
        }
        
        public void SetState(bool newState, bool flipped)
        {
            if (!isOpen)
            {
                flipDirection = flipped;
            }
            isOpen = newState;
            ResetTimer();
        }

        public void ToggleState(bool flipped)
        {
            if (!isOpen)
            {
                flipDirection = flipped;
            }
            isOpen = !isOpen;
            ResetTimer();
        }
        
        private void ResetTimer()
        {
            if (timeElapsed > moveTime)
            {
                timeElapsed = 0;
            }
            else
            {
                timeElapsed = moveTime - timeElapsed;
            }
        }

        private void Update()
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed <= moveTime)
            {
                float time = timeElapsed / moveTime;

                if (!isOpen)
                {
                    time = moveTime - time;
                }
                
                float currentAngle = Mathf.LerpAngle(closedAngle, openAngle, time);

                if (flipDirection) currentAngle *= -1;
                
                body.MoveRotation( initialRotation * Quaternion.Euler(axis * currentAngle));
            }
        }
    }
}