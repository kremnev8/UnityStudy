using Gameplay;
using UnityEngine;

namespace Study.Scripts.Gameplay.Player
{
    public class PlayerHoverModule : ControllerModule
    {
        public Transform cameraTransform;
        public LayerMask mask;

        public Task6Class3 last;
        
        protected override void OnUpdateModule()
        {
            Vector3 start = controller.GetPosition() + new Vector3(0, 1.6f, 0);
            if (Physics.Raycast(start, cameraTransform.forward, out RaycastHit hit, 50, mask))
            {
                Task6Class3 obj = hit.collider.gameObject.GetComponent<Task6Class3>();
                if (obj != null)
                {
                    obj.Green();
                    last = obj;
                }
                else if (last != null)
                {
                    last.Blue();
                    last = null;
                }
            }
            else if (last != null)
            {
                last.Blue();
                last = null;
            }
        }
    }
}