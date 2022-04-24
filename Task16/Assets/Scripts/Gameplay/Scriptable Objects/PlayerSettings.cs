using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "Player settings", menuName = "SO/Player Settings", order = 359)]
    public class PlayerSettings : CharacterSettings
    {
        [Header("Camera settings")]
        public float yAngleMin = 20f;
        public float yAngleMax = 70f;
        public float cameraDistance = 8f;
        public float minCameraDistance = 2f;
        public float cameraScrollSensitivity = 60f;
        public float rotationSpeed;
        public Vector3 cameraOffset;
        public Vector2 sensitivity;

        [Header("Player settings")] 
        public float runningMaxSpeed = 5f;
    }
}