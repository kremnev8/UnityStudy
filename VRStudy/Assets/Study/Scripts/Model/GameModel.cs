using Gameplay;
using Player;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;


namespace Model
{
    /// <summary>
    /// The main model containing needed data to implement a platformer style 
    /// game. This class should only contain data, and methods that operate 
    /// on the data. It is initialised with data in the GameController class.
    /// </summary>
    [System.Serializable]
    public class GameModel
    {
        public PlayerInput input;

        [FormerlySerializedAs("controller")] 
        public ModularCharacterController player;

        public PlayerSettings config;
        //[FormerlySerializedAs("outline")] public LayerSettings layer;
    }
}