using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Util;
using World;

namespace Gameplay.World
{
    public class Box : Button
    {
        public Rigidbody body;
        private AudioSource source;

        public bool canMove;
        public float maxBoxSpeed;
        public float maxVolume;
        
        
        protected override void Start()
        {
            base.Start();
            body = GetComponent<Rigidbody>();
            source = GetComponent<AudioSource>();
        }

        public void SetMoveState(bool value)
        {
            canMove = value;
            body.constraints = canMove ? RigidbodyConstraints.FreezeRotation : RigidbodyConstraints.FreezeAll;
        }

        private void Update()
        {
            base.Update();
            float speed = body.velocity.magnitude;
            float t = speed / maxBoxSpeed;
            float volume = Mathf.Lerp(0, maxVolume, t);

            source.volume = volume;
        }


        protected override bool InternalOnPressed()
        {
            SetMoveState(true);

            Vector3 playerPos = model.player.GetPosition();
            Vector3 direction = playerPos - body.position;
            direction.y = 0;
            direction.Normalize();
            
            Vector3 moveDir = direction.GetBiggestAxis();

            body.constraints = RigidbodyConstraints.FreezeRotation + (int)moveDir.GetConstaraints();
            return true;
        }

        protected override bool InternalOnReleased()
        {
            SetMoveState(false);
            return true;
        }
    }
}