using Gameplay;
using Model;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace World
{
    public class TriggerAutoSave : MonoBehaviour
    {
        public GameObject levelRoot;
        //private SaveController saves;
        private bool wasActivated;
        private GameModel model;

        private void Start()
        {
            model = GetModel<GameModel>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("NoPhysics")) return;
            if (!wasActivated && other.TryGetComponent(out ModularCharacterController controller))
            {
                
                wasActivated = true;

            }
        }
    }
}