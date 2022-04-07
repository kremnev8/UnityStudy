using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

namespace Study.Scripts
{
    public class Task12Class : MonoBehaviour
    {
        public string gameScene;
        public AudioMixer master;
        
        public void StartGame()
        {
            SceneManager.LoadScene(gameScene);
        }

        public void Exit()
        {
            #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
            #else
                Application.Quit();
            #endif
        }

        public void SetVolume(float value)
        {
            master.SetFloat("Volume", value);
        }
    }
}