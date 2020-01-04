using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using BoatAttack.UI;
using Random = UnityEngine.Random;

namespace BoatAttack
{
    public class RaceManager : MonoBehaviour
    {
        [Serializable]
        public enum GameType
        {
            Singleplayer = 0,
            LocalMultiplayer = 1,
            Multiplayer = 2,
            Spectator = 3,
            Benchmark = 4
        }
        
        [Serializable]
        public enum RaceType
        {
            Race,
            PointToPoint,
            TimeTrial
        }

        [Serializable]
        public class Race
        {
            //Race options
            public GameType game;
            public RaceType type;
            public int boatCount = 4; // currently hardcoded to 4

            //Level options
            public string level;
            public int laps = 3;
            public bool reversed;
            
            //Competitors
            public List<BoatData> boats;
        }

        public static RaceManager Instance;
        private bool _raceStarted;
		public Race raceData = new Race();
        private readonly Dictionary<int, float> _boatTimes = new Dictionary<int, float>();
        
        [Header("Assets")] public AssetReference[] boats;
        public AssetReference raceUiPrefab;
        
        private void OnEnable()
        {
            Instance = this;
            SceneManager.sceneLoaded += SetupRace;
            SetupRace(SceneManager.GetActiveScene(), LoadSceneMode.Single);
        }

        private void SetupRace(Scene scene, LoadSceneMode mode)
        {
            if (scene.name.Contains("level") || scene.name.Contains("demo"))
            {
                StartCoroutine(BeginRace()); // TODO need to make much better with race intro etc
            }
        }
        
        public void SetupGame(GameType gameType)
        {
            raceData.game = gameType;
            raceData.boats = new List<BoatData>();
            Debug.Log($"Game type set to:{raceData.game}");
            switch (raceData.game)
            {
                case GameType.Singleplayer:
                    BoatData b = new BoatData();
                    b.human = false; //true; // TODO for testing
                    raceData.boats.Add(b); // add player boat
                    GenerateRandomBoats(raceData.boatCount - 1); // add random AI
                    break;
                case GameType.Spectator:
                    GenerateRandomBoats(raceData.boatCount);
                    break;
            }
        }

        public void SetLevel(int levelIndex)
        {
            raceData.level = ConstantData.GetLevelName(levelIndex);
            Debug.Log($"Level set to:{levelIndex} with path:{raceData.level}");
        }

        public void SetHull(int player, int hull)
        {
            raceData.boats[player].boatPrefab = boats[hull];
        }

        public void LoadGame()
        {
            Application.backgroundLoadingPriority = ThreadPriority.Low;
            SceneManager.LoadSceneAsync(raceData.level);
        }

        private IEnumerator BeginRace()
        {
            yield return new WaitForSeconds(1f); // TODO should not wait here
            
            WaypointGroup.Instance.Reverse = raceData.reversed;
            WaypointGroup.Instance.Setup();
            
            yield return StartCoroutine(CreateBoats());

            switch (raceData.game)
            {
                case GameType.Singleplayer:
                    // Setup race UI
                    var uiLoading = raceUiPrefab.InstantiateAsync();
                    yield return uiLoading;
                    if (uiLoading.Result.TryGetComponent(out RaceUI uiComponent))
                    {
                        raceData.boats[0].Boat.RaceUi = uiComponent;
                        uiComponent.Setup(0);
                    }
                    // Setup race camera
                    Camera.main.cullingMask |= 1 << LayerMask.NameToLayer("Player1");
                    break;
                case GameType.Spectator:
                    ReplayCamera.Instance.EnableSpectatorMode(raceData.boats[0].BoatObject);
                    break;
            }

            _raceStarted = true;
        }

        void GenerateRandomBoats(int count, bool ai = true)
        {
            for (int i = 0; i < count; i++)
            {
                BoatData boat = new BoatData();
                Random.InitState(ConstantData.SeedNow+i);
                boat.boatName = ConstantData.AiNames[Random.Range(0, ConstantData.AiNames.Length)];
                BoatLivery livery = new BoatLivery
                {
                    primaryColor = ConstantData.GetRandomPaletteColor,
                    trimColor = ConstantData.GetRandomPaletteColor
                };
                boat.livery = livery;
                boat.boatPrefab = boats[Random.Range(0, boats.Length)];

                if (ai)
                    boat.human = false;

                raceData.boats.Add(boat);
            }
        }

        void Update()
        {
            if (_raceStarted)
            {
                for (int i = 0; i < raceData.boats.Count; i++)
                {
                    var boat = raceData.boats[i].Boat;
                    _boatTimes[i] = boat.LapPercentage + boat.LapCount;
                }
                var mySortedList = _boatTimes.OrderBy(d => d.Value).ToList();
                mySortedList.Reverse();
                var place = 1;
                foreach (var index in mySortedList)
                {
                    raceData.boats[index.Key].Boat.Place = place;
                    place++;
                }
            }
        }

        public int GetLapCount()
        {
            if (raceData != null && raceData.type == RaceType.Race)
            {
                return raceData.laps;
            }
            return -1;
        }

        private IEnumerator CreateBoats()
        {
            for (int i = 0; i < raceData.boats.Count; i++)
            {
                var boat = raceData.boats[i]; // boat to setup
                
                // Load prefab
                var startingPosition = WaypointGroup.Instance.StartingPositions[i];
                AsyncOperationHandle<GameObject> boatLoading = Addressables.InstantiateAsync(boat.boatPrefab, startingPosition.GetColumn(3),
                    Quaternion.LookRotation(startingPosition.GetColumn(2)));
                
                yield return boatLoading; // wait for boat asset to load
                
                boatLoading.Result.name = boat.boatName; // set the name of the boat
                boatLoading.Result.TryGetComponent<Boat>(out var boatController);
                boat.SetController(boatLoading.Result, boatController);
                boatController.Setup(i + 1, boat.human, boat.livery);
                _boatTimes.Add(i, 0f);
            }
            
        }
    }
}
