using System.Linq;
using UnityEngine;
using UnityEngine.Events;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Logic
{
    public class LogicRandom : MonoBehaviour
    {
        public UnityEvent[] outputs;
        public int outputCount;

        private void Awake()
        {
            if (outputs.Count() < outputCount)
                UpdateOutputs();
        }

        public void UpdateOutputs()
        {
            outputs = new UnityEvent[outputCount];
        }

        public void Trigger()
        {
            int result = Random.Range(0, outputCount);
            if (outputs.Length > result) 
                outputs[result]?.Invoke();
        }
    }
    
#if UNITY_EDITOR
    [CustomEditor(typeof(LogicRandom))]
    public class LogicRandomEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            LogicRandom trg = (LogicRandom) target;

            if (GUILayout.Button("UpdateOutputs"))
            {
                trg.UpdateOutputs();
            }
        }
    }
#endif
}