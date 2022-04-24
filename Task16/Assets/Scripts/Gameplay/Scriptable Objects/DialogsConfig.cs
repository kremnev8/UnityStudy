using System;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UI
{
    
    [Serializable]
    public class Dialog : GenericItem
    {
        public string dialogId;
        public string ItemId => dialogId;
        
        [TextArea]
        public string dialogText;

        public string speakerName;
        
    }
    
    [CreateAssetMenu(fileName = "New Dialogs config", menuName = "SO/New Dialogs config", order = 359)]
    public class DialogsConfig : GenericDB<Dialog>
    {
    }
}