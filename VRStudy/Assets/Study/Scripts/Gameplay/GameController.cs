using System;
using System.Collections.Generic;
using Gameplay.UI;
using Model;
using Platformer.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay
{
    public class GameController : MonoBehaviour
    {
        public static GameController instance;
        
        public GameModel model;

        public static Action onDone;
    
        private void Awake()
        {
            instance = this;
            Simulation.SetModel(model);
           // LoadLevel(0);
        }
        
        public void RestartLevel()
        {
           /// LoadLevel(currentLevel);
        }
        
        public void LoadNext()
        {
           // LoadLevel(currentLevel + 1);
        }

       /* public void LoadLevel(int level)
        {
            if (level >= levels.Length)
            {
                onDone?.Invoke();
                return;
            }

            if (root != null)
            {
                root.ClearChildren();
                Destroy(root);
            }

            currentLevel = level;
            Invoke(nameof(FinishLoad), 0.5f);
        }*/

        private void FinishLoad()
        {
           // root = Instantiate(levels[currentLevel], target);
        }
    }
}