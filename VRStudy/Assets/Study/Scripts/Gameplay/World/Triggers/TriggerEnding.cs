using UnityEditor;
using UnityEngine;

namespace Gameplay.World
{
    public class TriggerEnding : MonoBehaviour
    {
        public void Trigger()
        {
         //   FindObjectOfType<SceneTransitionManager>().LoadEnding();
        }

        public void Quit()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#elif (UNITY_STANDALONE) 
    Application.Quit();
#elif (UNITY_WEBGL)
    Application.OpenURL("about:blank");
#endif
        }
    }
}