using System;
using UnityEngine;

namespace Player
{
    [Serializable]
    public class Level
    { 
        public int index;
        public string name;
        public Sprite icon;
    }
    
    [CreateAssetMenu(fileName = "Level Settings", menuName = "SO/Level Settings", order = 0)]
    public class LevelSettings : ScriptableObject
    {
        public Level[] levels;
    }
}