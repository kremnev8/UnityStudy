using System;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

namespace Gameplay.Player.Inventory
{
    [Serializable]
    public class Item : GenericItem
    {
        public string itemId;
        public string ItemId => itemId;
        
        public string name;
        public string description;
        public Sprite icon;
        public GameObject prefab;
    }
    
    [CreateAssetMenu(fileName = "Item DB", menuName = "SO/New Item DB", order = 0)]
    public class ItemDB : GenericDB<Item>
    {
    }
}