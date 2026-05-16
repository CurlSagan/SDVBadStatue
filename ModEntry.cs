using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Monsters;
using Microsoft.Xna.Framework;

namespace GhostStatueMod
{
    public class ModEntry : Mod
    {
        private const int GHOST_SPAWN_INTERVAL = 600000; // 10 minutes in milliseconds
        private int timeSinceLastSpawn = 0;

        public override void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.UpdateTicked += OnUpdateTicked;
            helper.Events.GameLoop.DayStarted += OnDayStarted;
            this.Monitor.Log("Ghost Statue Mod loaded!", LogLevel.Info);
        }

        private void OnUpdateTicked(object sender, UpdateTickedEventArgs e)
        {
            if (!Context.IsWorldReady)
                return;

            timeSinceLastSpawn += (int)Game1.currentGameTime.ElapsedGameTime.TotalMilliseconds;

            if (timeSinceLastSpawn >= GHOST_SPAWN_INTERVAL)
            {
                SpawnGhost();
                timeSinceLastSpawn = 0;
            }
        }

        private void OnDayStarted(object sender, DayStartedEventArgs e)
        {
            timeSinceLastSpawn = 0;
            this.Monitor.Log("Ghost spawn timer reset for new day", LogLevel.Debug);
        }

        private void SpawnGhost()
        {
            try
            {
                Farm farm = Game1.getFarm();
                
                // Spawn ghost at a reasonable farm location (center-ish)
                Vector2 spawnPosition = new Vector2(40, 10);
                
                Ghost ghost = new Ghost(spawnPosition);
                farm.addCharacter(ghost);
                
                this.Monitor.Log($"Ghost spawned at {spawnPosition}", LogLevel.Debug);
            }
            catch (Exception ex)
            {
                this.Monitor.Log($"Error spawning ghost: {ex.Message}", LogLevel.Error);
            }
        }
    }
}
