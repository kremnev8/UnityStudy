using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "Character settings", menuName = "SO/Character Settings", order = 359)]
    public class CharacterSettings : ScriptableObject
    {
        [Header("Character settings")] 
        public float normalMaxSpeed = 5f;
        
        public float moveSmoothTime = 1f;
        public float airMoveSmoothTime = 1f;
        public float slopeForceRayLength = 1;
        public float slopeForce = 1f;

        public float friction = 0.8f;
        public float gravityAcceleration = 1f;

        public float lookSmoothTime = 0.1f;
    }
}