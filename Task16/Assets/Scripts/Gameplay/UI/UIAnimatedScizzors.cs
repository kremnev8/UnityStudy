using System;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.UI
{
    public class UIAnimatedScizzors : MonoBehaviour
    {
        public RectTransform top;
        public RectTransform bottom;

        public float travel;
        public float travelSpeed;
        
        public float maxAngle = 15;
        public float rotateSpeed;

        public bool isActive;

        private float timeElapsed;

        public UnityEvent onFinished;

        public void Activate()
        {
            isActive = true;
        }
        
        
        private void Update()
        {
            if (isActive)
            {
                timeElapsed += Time.deltaTime;
                float currentAngle = Mathf.Lerp(0, maxAngle, Mathf.Sin(timeElapsed * rotateSpeed));
                
                top.rotation = Quaternion.Euler(0,0, currentAngle);
                bottom.rotation = Quaternion.Euler(0,0, -currentAngle);
                
                float position = Mathf.Lerp(0, travel, timeElapsed / travelSpeed);
                top.anchoredPosition += new Vector2(position, 0);
                bottom.anchoredPosition += new Vector2(position, 0);

                if (top.anchoredPosition.x <= travel)
                {
                    onFinished?.Invoke();
                    isActive = false;
                }
            }
        }
    }
}