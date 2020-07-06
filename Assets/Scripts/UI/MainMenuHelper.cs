using TMPro;
using UnityEngine;

namespace BoatAttack.UI
{
    public class MainMenuHelper : MonoBehaviour
    {
        [Header("Level Selection")] public EnumSelector levelSelector;
        public EnumSelector lapSelector;
        public EnumSelector reverseSelector;

        [Header("Boat Selection")] public GameObject[] boatMeshes;
        public TextMeshProUGUI boatName;
        public EnumSelector boatHullSelector;
        public ColorSelector boatPrimaryColorSelector;
        public ColorSelector boatTrimColorSelector;

        private void OnEnable()
        {
            // level stuff
            levelSelector.updateVal += SetLevel;
            lapSelector.updateVal += SetLaps;
            reverseSelector.updateVal += SetReverse;
            // boat stuff
            boatHullSelector.updateVal += UpdateBoat;
            boatPrimaryColorSelector.updateVal += UpdatePrimaryColor;
            boatTrimColorSelector.updateVal += UpdateTrimColor;
        }

        private void SetupDefaults()
        {
            // level stuff
            SetLevel(levelSelector.CurrentOption);
            SetLaps(lapSelector.CurrentOption);
            SetReverse(reverseSelector.CurrentOption);
            // boat stuff
            SetSinglePlayerName(boatName.text);
            UpdateBoat(0);
            UpdateBoatColor(boatPrimaryColorSelector.CurrentOption, true);
            UpdateBoatColor(boatTrimColorSelector.CurrentOption, false);
        }

        private void UpdateBoat(int index)
        {
            RaceManager.SetHull(0, index);
            for (var i = 0; i < boatMeshes.Length; i++)
            {
                boatMeshes[i].SetActive(i == index);
            }
        }

        public void SetupSingleplayerGame()
        {
            RaceManager.SetGameType(RaceManager.GameType.Singleplayer);
            SetupDefaults();
        }

        public void SetupSpectatorGame()
        {
            RaceManager.SetGameType(RaceManager.GameType.Spectator);
            SetupDefaults();
        }

        private static void SetLevel(int index) => RaceManager.SetLevel(index);

        private static void SetLaps(int index) => RaceManager.RaceData.laps = ConstantData.Laps[index];

        private static void SetReverse(int reverse) => RaceManager.RaceData.reversed = reverse == 1;

        public void StartRace() => RaceManager.LoadGame();

        public void SetSinglePlayerName(string playerName) => RaceManager.RaceData.boats[0].boatName = playerName;

        private void UpdatePrimaryColor(int index) => UpdateBoatColor(index, true);

        private void UpdateTrimColor(int index) => UpdateBoatColor(index, false);

        private void UpdateBoatColor(int index, bool primary)
        {
            // update racedata
            if (primary)
            {
                RaceManager.RaceData.boats[0].livery.primaryColor = ConstantData.GetPaletteColor(index);
            }
            else
            {
                RaceManager.RaceData.boats[0].livery.trimColor = ConstantData.GetPaletteColor(index);
            }
            
            // update menu boats
            foreach (var t in boatMeshes)
            {
                var renderers = t.GetComponentsInChildren<MeshRenderer>(true);
                foreach (var rend in renderers)
                {
                    rend.material.SetColor(primary ? "_Color1" : "_Color2", ConstantData.GetPaletteColor(index));
                }
            }
        }
    }
}
