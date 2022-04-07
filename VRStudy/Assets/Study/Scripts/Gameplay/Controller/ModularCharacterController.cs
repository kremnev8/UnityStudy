using System;
using System.Collections.Generic;
using System.Linq;
using Player;
using UnityEngine;


namespace Gameplay
{
    public abstract class ModularCharacterController : MonoBehaviour
    {
        public bool onGround;

        public float testDistance = 0.5f;
        public LayerMask groundLayerMask;
        public bool controlEnabled = true;

        public List<ControllerModule> modules;
        
        private List<Type> blacklisted = new List<Type>();

        public CharacterSettings config;

        public T GetModule<T>() where T : ControllerModule
        {
            return (T) modules.Find(module => module.GetType() == typeof(T));
        }
        
        public void SetControlEnabled(bool value)
        {
            controlEnabled = value;
            if (!value)
            {
                SetAngularVelocity(Vector3.zero);
            }
        }
        
        
        public abstract void SetVelocity(Vector3 newVelocity);
        public abstract Vector3 GetVelocity();
        public abstract void SetPosition(Vector3 position, bool resetVelocity = true);
        public abstract Vector3 GetPosition();
        public abstract void SetAngularVelocity(Vector3 velocity);
        
        protected abstract bool IsGrounded();
        public abstract float GetCharacterHeight();
        public abstract bool OnSlope(out Vector3 normal);


        public void SetVelocity(float speed, int index)
        {
            Vector3 newVelocity = GetVelocity();
            newVelocity[index] = speed;
            
            SetVelocity(newVelocity);
        }
        
        public void AddVelocity(Vector3 newVelocity)
        {
            SetVelocity(GetVelocity() + newVelocity);
        }

        public void AddVelocity(float speed, int index) 
        {
            Vector3 newVelocity = GetVelocity();
            newVelocity[index] += speed;
            
            SetVelocity(newVelocity);
        }

        public void SetPosition(float pos, int index)
        {
            Vector3 newVelocity = GetVelocity();
            Vector3 newPosition = GetPosition();
            newVelocity[index] = 0;
            newPosition[index] = pos;
            
            SetPosition(newPosition, false);
            SetVelocity(newVelocity);
        }
        
        protected virtual void Start()
        {
            modules = GetComponents<ControllerModule>().ToList();
            foreach (ControllerModule module in modules)
            {
                module.InitModule();
            }
        }


        private void FixedUpdate()
        {
            onGround = IsGrounded();
            blacklisted.Clear();
            foreach (ControllerModule module in modules)
            {
                blacklisted.AddRange(module.getBlacklistedModules());
            }
            
            foreach (ControllerModule module in modules)
            {
                if (module.DoesImplementControl() && !controlEnabled) continue;
                if (blacklisted.Contains(module.GetType())) return;
                
                module.UpdateModule();
            }
        }
        

    }
}