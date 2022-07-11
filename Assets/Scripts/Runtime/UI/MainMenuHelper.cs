using UnityEngine;

namespace BoatAttack.UI
{
    public class MainMenuHelper : MonoBehaviour
    {
        [Header("Level Selection")] public LevelSelectHelper levelSelector;
        [Header("Boat Selection")] public BoatSelectHelper boatSelector;
        
        private void OnEnable()
        {
            //New code
            boatSelector.Init();
            levelSelector.Init();
        }
        
        public void SetupSingleplayerGame()
        {
            RaceManager.SetGameType(RaceManager.GameType.Singleplayer);
        }

        public void SetupSpectatorGame()
        {
            RaceManager.SetGameType(RaceManager.GameType.Spectator);
        }
        
        public void StartRace() => RaceManager.LoadGame();

        public void SetSinglePlayerName(string playerName) => RaceManager.RaceData.boats[0].name = playerName;
    }
}
