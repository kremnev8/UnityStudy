using System;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UI
{
    [Serializable]
    public class Hint : GenericItem
    {
        public string hintId;
        public string ItemId => hintId;
        
        public InputActionProperty action;
        public string hintText;
        
    }
    
    
    [CreateAssetMenu(fileName = "New Hints Config", menuName = "SO/New Hints Config", order = 359)]
    public class HintsConfig : GenericDB<Hint>
    {

        public string GetHintTextFormatted(Hint hint)
        {
            if (hint.action.action.bindings.Count > 0)
            {
                return string.Format(hint.hintText, hint.action.action.bindings[0].ToDisplayString());
            }
            return hint.hintText;
        }
    }
}