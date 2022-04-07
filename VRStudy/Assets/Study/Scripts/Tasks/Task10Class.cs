using Model;
using Platformer.Core;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Study.Scripts
{
    public class Task10Class : MonoBehaviour
    {
        private PlayerInput _input;
        private InputAction rAction;

        private int curScene = 0;
        public string[] scenes;


        private static Task10Class instance;

        private void Start()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
            
            _input = Simulation.GetModel<GameModel>().input;
            rAction = _input.actions["rUse"];
            rAction.performed += OnPressed;
            DontDestroyOnLoad(gameObject);
        }

        private void OnPressed(InputAction.CallbackContext obj)
        {
            curScene++;
            if (curScene >= scenes.Length)
            {
                curScene = 0;
            }

            SceneManager.LoadScene(scenes[curScene]);
        }
    }
}