using System;
using UnityEngine;

namespace Controllers
{

    [Serializable]
    public struct AttachState
    {
        public Vector3 attachPosition;
        public Vector3 attachRotation;
    }
    public class AttachableObject : MonoBehaviour
    {
        public AttachState[] states;
        public string attachKey;
        private Collider myCollider;

        private void Awake()
        {
            myCollider = GetComponent<Collider>();
        }

        public void SetColliderState(bool newState)
        {
            myCollider.enabled = newState;
        }

        public void Attach(Transform parent, int state)
        {
            if (state < 0 || states.Length <= state) return;
            if (parent == null) return;
            
            
            
            AttachState newState = states[state];
            
            var myTransform = transform;
            myTransform.parent = parent;
            myTransform.localPosition = newState.attachPosition;
            myTransform.localRotation = Quaternion.Euler(newState.attachRotation);
        }
    }
}