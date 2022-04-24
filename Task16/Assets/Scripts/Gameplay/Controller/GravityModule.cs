using Cinemachine.Utility;
using UnityEngine;

namespace Gameplay
{
    public class GravityModule : ControllerModule
    {
        
        private float velocityY = 0.0f;

        protected override void OnInit()
        {
        }
        
        protected override void OnUpdateModule()
        {
            if(controller.onGround)
                velocityY = 0.0f;

            if (controller.GetVelocity().sqrMagnitude > 0.1f && controller.OnSlope(out Vector3 normal))
            {
                Vector3 planeDir = normal.ProjectOntoPlane(Vector3.up).normalized;
                Vector3 playerDir = controller.GetVelocity();
                playerDir.y = 0;
                playerDir.Normalize();
                if (Vector3.Dot(planeDir, playerDir) > 0)
                {
                    velocityY -= controller.GetCharacterHeight() / 2 * config.slopeForce;
                }
            }
            
            velocityY += -config.gravityAcceleration * Time.deltaTime;

            controller.AddVelocity( new Vector3(0, velocityY, 0));
            
            //_controller3D._body.MovePosition(controller.GetPosition() +  new Vector3(0, velocityY, 0) * Time.deltaTime);
        }
        
        public override bool DoesImplementControl()
        {
            return true;
        }
    }
}