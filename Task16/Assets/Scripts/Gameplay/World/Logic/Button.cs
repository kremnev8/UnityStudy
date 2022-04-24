using Controllers;
using Model;
using Platformer.Core;
using UnityEngine;
using UnityEngine.InputSystem;
using UI;
using UnityEngine.Events;

namespace World
{
    public class Button : HintVolume
    {
        public UnityEvent pressed;
        public UnityEvent released;
        
        protected InputAction useAction;
        public bool isEnabled = true;
        public string hintID;

        protected virtual bool InternalOnPressed()
        {
            return true;
        }
        
        protected virtual bool InternalOnReleased()
        {
            return true;
        }
        

        public void SetEnabled(bool newState)
        {
            isEnabled = newState;
        }
        
        protected override string GetHintID()
        {
            return hintID;
        }

        protected override void Start()
        {
            base.Start();
            
            if (model.input == null) return;
            
            useAction = model.input.actions["use"];
            useAction.started += OnPressed;
            useAction.performed += OnReleased;
        }

        private void OnDisable()
        {
            if (useAction != null)
                useAction.started -= OnPressed;
        }


        protected void OnPressed(InputAction.CallbackContext ctx)
        {
            if (!isDisplayingHint) return;

            if (InternalOnPressed())
                pressed?.Invoke();
        }
        
        protected void OnReleased(InputAction.CallbackContext obj)
        {
            if (!isDisplayingHint) return;
            if (obj.action.IsPressed()) return;
            
            if (InternalOnReleased())
                released?.Invoke();
        }
    }
}