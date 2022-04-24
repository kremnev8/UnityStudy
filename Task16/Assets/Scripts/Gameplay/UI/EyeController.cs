using System;
using UnityEngine;

namespace Gameplay.UI
{
    public class EyeController : MonoBehaviour
    {
        public RectTransform topLid;
        public RectTransform bottomLid;

        public float closeTime = 1;
        public float openTime = 1;

        public float openPos = 450;
        public float closedPos = 0;

        public bool isOpen;
        public float timeElapsed;

        public void SetState(bool state)
        {
            isOpen = state;
            timeElapsed = 0;
        }

        public void Toggle()
        {
            SetState(!isOpen);
        }
        
        
        public void Update()
        {
            timeElapsed += Time.deltaTime;

            float moveTime = isOpen ? closeTime : openTime;
            
            if (timeElapsed <= moveTime)
            {
                float time = timeElapsed / moveTime;

                if (!isOpen)
                {
                    time = 1 - time;
                }

                float pos = Mathf.Lerp(closedPos, openPos, time);
                topLid.anchoredPosition = new Vector2(0, pos);
                bottomLid.anchoredPosition = new Vector2(0, -pos);
            }
        }
    }
}