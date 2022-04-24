using UnityEngine;

namespace Gameplay
{
    public class AnimationModule : ControllerModule
    {
        public Animator animator;
        public string speedName = "speed";
        
        protected override void OnUpdateModule()
        {
            float speed =  controller.GetVelocity().magnitude;
            animator.SetFloat(speedName, speed);

        }
    }
}