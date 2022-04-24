using System;
using Controllers;
using TMPro;
using UnityEngine;

namespace UI
{
    public class HintsUI : MonoBehaviour
    {
        public TextMeshProUGUI textMesh;
        public GameObject parent;
        public HintsConfig hintList;


        private void Start()
        {
          //  SaveController controller = FindObjectOfType<SaveController>();
          //  if (controller != null)
           //     textMesh.fontSize = hintList.fontSizes[controller.data.fontSize];
        }

        public void DisplayHint(string id)
        {
            Hint hint = hintList.Get(id);
            if (hint == null) return;
            
            string hintTextForm = hintList.GetHintTextFormatted(hint);
            textMesh.text = hintTextForm;
            parent.SetActive(true);
        }

        public void SetHintState(bool state)
        {
            parent.SetActive(state);
        }

        public void Hide()
        {
            parent.SetActive(false);
        }
    }
}