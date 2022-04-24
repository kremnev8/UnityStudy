using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Controllers;
using Model;
using Platformer.Core;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace UI
{
    public class DialogUI : MonoBehaviour
    {
        public TMP_Text textMesh;
        public TMP_Text authorText;
        
        public GameObject parent;
        public RectTransform content;
        public HintsUI hintsUI;
        
        
        public DialogsConfig dialogsList;
        private bool isOpen;

        private GameModel model;
        private InputAction closeAction;
        


        private void Start()
        {
            model = Simulation.GetModel<GameModel>();
            closeAction = model.input.actions["close"];
            closeAction.performed += OnClose;
        }

        private void OnClose(InputAction.CallbackContext obj)
        {
            if (isOpen)
            {
                HideDialog();
            }
        }


        public Dialog GetDialog(string id)
        {
            return dialogsList.Get(id);
        }

        public void DisplayDialog(Dialog dialog)
        {
            FPCameraController.LockCursor(false);
            model.player.SetControlEnabled(false);
            hintsUI.SetHintState(false);
            isOpen = true;
            textMesh.text = dialog.dialogText;
            authorText.text = "- " + dialog.speakerName;
            textMesh.Rebuild(CanvasUpdate.PreRender);
            parent.SetActive(true);
            StartCoroutine(UpdateSizeLater());
            
        }

        private IEnumerator UpdateSizeLater()
        {
            yield return new WaitForSeconds(0.1f);

            float height = textMesh.preferredHeight + 20f;

            content.sizeDelta = new Vector2(content.sizeDelta.x, height);

            yield return null;
        }
        
        public void HideDialog()
        {
            parent.SetActive(false);
            isOpen = false;
            FPCameraController.LockCursor(true);
            model.player.SetControlEnabled(true);
            hintsUI.SetHintState(true);
        }
    }
}