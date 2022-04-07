using System;
using Model;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace Study.Scripts
{
    public class Task11Class : MonoBehaviour
    {
        public GameObject pane;
        public Image image;

        public Sprite[] images;
        private int curImage = 0;

        private void Start()
        {
            image.sprite = images[curImage];
            FPCameraController.LockCursor(false);
            FPCameraController.isEnabled = false;
        }

        public void Close()
        {
            pane.SetActive(false);
            FPCameraController.LockCursor(true);
            FPCameraController.isEnabled = true;
        }

        public void ChangeImage()
        {
            curImage++;
            if (curImage >= images.Length)
            {
                curImage = 0;
            }
            image.sprite = images[curImage];
        }

    }
}