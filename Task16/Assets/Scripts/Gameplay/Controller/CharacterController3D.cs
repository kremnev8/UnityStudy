using UnityEngine;

namespace Gameplay
{
    public class CharacterController3D : ModularCharacterController
    {
        [HideInInspector] public Rigidbody _body;
        [HideInInspector] public CapsuleCollider _collider;

        public override void SetVelocity(Vector3 newVelocity)
        {
            _body.velocity = newVelocity;
        }

        public override Vector3 GetVelocity()
        {
            return _body.velocity;
        }
        
        public override void SetPosition(Vector3 position, bool resetVelocity = true)
        {
            _body.position = position;
            SetVelocity(Vector3.zero);
        }
        
        public override Vector3 GetPosition()
        {
            return _body.position;
        }

        public override void SetAngularVelocity(Vector3 velocity)
        {
            _body.angularVelocity = velocity;
        }

        protected override bool IsGrounded()
        {
            Vector3 center = _body.position + _collider.center;
            float height = _collider.height;
            bool isHit = Physics.SphereCast(center, _collider.radius, Vector3.down, out RaycastHit hit, testDistance + height / 4.0f);
            
            if (isHit) return hit.collider != null;
            return false;
        }
        
        public override float GetCharacterHeight()
        {
            return _collider.height;
        }
        
        public override bool OnSlope(out Vector3 normal)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, Vector3.down, out hit, _collider.height / 2 * config.slopeForceRayLength))
                if (hit.normal != Vector3.up)
                {
                    normal = hit.normal;
                    return true;
                }
                
            normal = Vector3.up;
            return false;
        }

        protected override void Start()
        {
            _body = GetComponent<Rigidbody>();
            _collider = GetComponent<CapsuleCollider>();
            
            base.Start();
        }
    }
}