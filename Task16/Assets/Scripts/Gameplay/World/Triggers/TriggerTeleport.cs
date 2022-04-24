using System;
using Cinemachine.Utility;
using Controllers;
using Gameplay;
using UnityEngine;

namespace World
{
    public class TriggerTeleport : MonoBehaviour
    {
        public Transform targetPosition;
        public Vector3 teleportAxis;
        public bool oneAxis;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("NoPhysics")) return;
            if (other.TryGetComponent(out ModularCharacterController controller))
            {
                Vector3 newPos;
                if (oneAxis)
                {
                    Vector3 inv = (teleportAxis - Vector3.one).Abs();
                    newPos = Vector3.Scale(targetPosition.position, teleportAxis) +
                                     Vector3.Scale(controller.transform.position, inv);
                }
                else
                {
                    newPos = targetPosition.position;
                }

                controller.SetPosition(newPos, false);
            }
        }


        public void TeleportRemote()
        {
            ModularCharacterController controller = FindObjectOfType<ModularCharacterController>();
                
            Vector3 newPos;
            if (oneAxis)
            {
                Vector3 inv = (teleportAxis - Vector3.one).Abs();
                newPos = Vector3.Scale(targetPosition.position, teleportAxis) +
                         Vector3.Scale(controller.transform.position, inv);
            }
            else
            {
                newPos = targetPosition.position;
            }
                
            controller.SetPosition(newPos, false);
        }
    }
}