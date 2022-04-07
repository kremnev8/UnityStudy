using UnityEngine;
using UnityEngine.Events;

namespace Controllers
{
    public class ItemRecepticle : MonoBehaviour
    {
        public string insertKey;
        public bool isInserted;
        public Transform insertTransform;

        public UnityEvent inserted;
        
        public bool CanInsert(AttachableObject obj)
        {
            return insertKey == obj.attachKey && !isInserted;
        }

        public bool TryInsert(AttachableObject obj)
        {
            if (CanInsert(obj))
            {
                obj.Attach(insertTransform, 1);
                obj.SetColliderState(true);
                isInserted = true;
                inserted?.Invoke();
                return true;
            }

            return false;
        }
    }
}