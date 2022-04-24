using System;
using Model;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;
using static Platformer.Core.Simulation;

namespace Gameplay
{
    public class ControllerModule : MonoBehaviour
    {
        public bool isEnabled { get; protected set; }
        protected ModularCharacterController controller;
        protected CharacterSettings config;
        
        public void InitModule()
        {
            controller = GetComponent<ModularCharacterController>();
            config = controller.config;
            isEnabled = true;
            OnInit();
        }
        
        public void UpdateModule()
        {
            if (!ShouldBeActive()) return;
            if (!isEnabled) return;

            OnReciveInputs();
            OnUpdateModule();
        }

        protected virtual bool ShouldBeActive()
        {
            return true;
        }

        public virtual bool DoesImplementControl()
        {
            return false;
        }

        public virtual Type[] getBlacklistedModules()
        {
            return new Type[0];
        }
        
        protected virtual void OnReciveInputs()
        {
            
        }

        protected virtual void OnUpdateModule()
        {
            
        }

        protected virtual void OnInit()
        {
            
        }
    }
}