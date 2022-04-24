using System;
using UnityEngine;

namespace Gameplay.World
{
    public class Terminator : MonoBehaviour
    {
        protected virtual void Start()
        {
            Terminate();
        }

        public void Terminate()
        {
            ClearChildren();
            Destroy(gameObject);
        }

        public void ClearChildren()
        {
            int i = 0;

            //Array to hold all child obj
            GameObject[] allChildren = new GameObject[transform.childCount];

            //Find all child obj and store to that array
            foreach (Transform child in transform)
            {
                allChildren[i] = child.gameObject;
                i += 1;
            }

            //Now destroy them
            foreach (GameObject child in allChildren)
            {
                Destroy(child.gameObject);
            }

        }
    }
}