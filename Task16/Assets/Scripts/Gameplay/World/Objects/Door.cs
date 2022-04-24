using System;
using Cinemachine.Utility;
using UnityEngine;
using Util;

namespace Gameplay.World
{
    public class Door : MonoBehaviour
    {
        private Rigidbody body;
        public Vector3 axis;
        
        
        public float closedPos;
        public float openPos;

        public bool isOpen;
        
        public float moveTime;
        private float timeElapsed;
        
        private void Awake()
        {
            body = GetComponent<Rigidbody>();
            timeElapsed = moveTime;
        }

        public void SetState(bool newState)
        {
            isOpen = newState;
            ResetTimer();
        }

        public void ToggleState()
        {
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

        private void FixedUpdate()
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed <= moveTime)
            {
                float time = timeElapsed / moveTime;

                if (!isOpen)
                {
                    time = 1 - time;
                }

                float pos = Mathf.Lerp(closedPos, openPos, time);
                
                Vector3 targetPos = transform.parent.TransformPoint(axis * pos);    
                
                body.MovePosition(targetPos);
            }
        }
    }
}