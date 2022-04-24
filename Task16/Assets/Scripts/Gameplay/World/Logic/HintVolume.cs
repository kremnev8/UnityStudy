using System;
using System.Collections;
using Model;
using Platformer.Core;
using UI;
using UnityEngine;
using Util;

namespace UI
{
    public abstract class HintVolume : MonoBehaviour
    {
        public Transform lookAt;
        
        protected GameModel model;
        protected bool isDisplayingHint;
        protected HintsUI HintsUI;
        protected bool DoDisplayHint = true;

        private bool playerInside;
        public static HintVolume currentVolume;
        
        protected abstract string GetHintID();
        
        protected void SetDoDisplayHint(bool newState)
        {
            DoDisplayHint = newState;
            if (isDisplayingHint && !DoDisplayHint)
            {
                HintsUI.Hide();
                isDisplayingHint = false;
            }
        }

        public void Hide()
        {
            HintsUI.Hide();
            isDisplayingHint = false;
            if (currentVolume == this)
            {
                currentVolume = null;
            }
        }

        public void Show()
        {
            if (currentVolume != null)
            {
                float myDist = (transform.position - model.player.GetPosition()).ToVector2().magnitude;
                float otherDist = (currentVolume.transform.position - model.player.GetPosition()).ToVector2().magnitude;
                
                if (myDist > otherDist) return;
                currentVolume.Hide();
            }
            
            HintsUI.DisplayHint(GetHintID());
            isDisplayingHint = true;
            currentVolume = this;
        }
        
        protected virtual void Start()
        {
            HintsUI = FindObjectOfType<HintsUI>();
            model = Simulation.GetModel<GameModel>();
        }

        private void CheckLookAndDisplayHint()
        {
            if (!DoDisplayHint) return;
            
            if (lookAt == null)
            {
                if (!isDisplayingHint)
                    Show();
            }
            else
            {
                Vector2 direction = (lookAt.position - model.player.GetPosition()).ToVector2().normalized;
                Vector2 lookDir = model.player.transform.forward.ToVector2().normalized;
                if (Vector2.Dot(direction, lookDir) > 0)
                {
                    Show();
                }else if (isDisplayingHint)
                {
                    Hide();
                }
                
            }
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                playerInside = true;
                CheckLookAndDisplayHint();

            }
        }

        protected virtual void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                playerInside = false;
                Hide();
            }
        }

        protected void Update()
        {
            if (playerInside)
            {
                CheckLookAndDisplayHint();
            }
        }
    }
}