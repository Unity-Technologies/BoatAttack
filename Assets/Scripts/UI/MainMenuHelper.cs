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

//        private void OnDisable()
//        {
//            // level stuff
//            levelSelector.updateVal -= SetLevel;
//            lapSelector.updateVal -= SetLaps;
//            reverseSelector.updateVal -= SetReverse;
//            // boat stuff
//            boatHullSelector.updateVal -= UpdateBoat;
//            boatPrimaryColorSelector.updateVal -= UpdatePrimaryColor;
//            boatTrimColorSelector.updateVal -= UpdateTrimColor;
//        }

        void UpdateBoat(int index)
        {
            RaceManager.Instance.SetHull(0, index);
            for (int i = 0; i < boatMeshes.Length; i++)
            {
                boatMeshes[i].SetActive(i == index);
            }
        }

        public void SetupSingleplayerGame()
        {
            RaceManager.Instance.SetupGame(RaceManager.GameType.Singleplayer);
            SetupDefaults();
        }

        public void SetupSpectatorGame()
        {
            RaceManager.Instance.SetupGame(RaceManager.GameType.Spectator);
            SetupDefaults();
        }

        private static void SetLevel(int index) { RaceManager.Instance.SetLevel(index); }
        
        private static void SetLaps(int index) { RaceManager.Instance.raceData.laps = ConstantData.Laps[index]; }
        
        private static void SetReverse(int reverse) { RaceManager.Instance.raceData.reversed = reverse == 1; }
        
        public void StartRace() { RaceManager.Instance.LoadGame(); }
        
        public void SetSinglePlayerName(string playerName) { RaceManager.Instance.raceData.boats[0].boatName = playerName; }
        
        private void UpdatePrimaryColor(int index) { UpdateBoatColor(index, true); }
        
        private void UpdateTrimColor(int index) { UpdateBoatColor(index, false); }

        private void UpdateBoatColor(int index, bool primary)
        {
            // update racedata
            if (primary)
            {
                RaceManager.Instance.raceData.boats[0].livery.primaryColor = ConstantData.GetPaletteColor(index);
            }
            else
            {
                RaceManager.Instance.raceData.boats[0].livery.trimColor = ConstantData.GetPaletteColor(index);
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
