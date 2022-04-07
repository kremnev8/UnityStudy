

namespace Gameplay
{
    public class PlayerTeleportModule : ControllerModule
    {
        public bool teleportToSpawnOnStart;
        
        protected override void OnInit()
        {
            if (teleportToSpawnOnStart)
            {
               // SpawnPlayer();
            }
        }

    }
}