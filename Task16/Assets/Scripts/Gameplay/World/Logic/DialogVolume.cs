using System;
using System.Collections;
using UI;
using UnityEngine;

namespace UI
{
    public class DialogVolume : MonoBehaviour
    {
        private DialogUI dialogUI;
        private bool wasShown = false;
        
        public string dialogId;
        public bool displayOnce = true;
        

        private void Start()
        {
            dialogUI = FindObjectOfType<DialogUI>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            if (displayOnce && wasShown) return;
            
            dialogUI.DisplayDialog(dialogUI.GetDialog(dialogId));
            wasShown = true;
        }

        public void TriggerDialogRemote()
        {
            if (displayOnce && wasShown) return;
            
            dialogUI.DisplayDialog(dialogUI.GetDialog(dialogId));
            wasShown = true;
        }
        
    }
}