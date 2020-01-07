using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using BoatAttack.UI;
using UnityEngine.Serialization;
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
        [NonSerialized] public static bool RaceStarted;
        public static Race RaceData;
		[FormerlySerializedAs("raceData")]
        public Race demoRaceData = new Race();
        [NonSerialized] public static float RaceTime;
        private readonly Dictionary<int, float> _boatTimes = new Dictionary<int, float>();

        public static void BoatFinished(int player)
        {
            Debug.Log($"Player {player + 1} just finished.");

            switch (RaceData.game)
            {
                case GameType.Singleplayer:
                    if (player == 0)
                    {
                        var raceUi = RaceData.boats[0].Boat.RaceUi;
                        raceUi.SetGameplayUi(false);
                        raceUi.SetGameStats(true);
                        ReplayCamera.Instance.EnableSpectatorMode();
                    }
                    break;
                case GameType.LocalMultiplayer:
                    break;
                case GameType.Multiplayer:
                    break;
                case GameType.Spectator:
                    break;
                case GameType.Benchmark:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        [Header("Assets")] public AssetReference[] boats;
        public AssetReference raceUiPrefab;

        private void OnEnable()
        {
            Instance = this;
            RaceData = demoRaceData;
            SceneManager.sceneLoaded += SetupRace;
            SetupRace(SceneManager.GetActiveScene(), LoadSceneMode.Single);
        }

        private static void SetupRace(Scene scene, LoadSceneMode mode)
        {
            WaypointGroup.Instance.Setup(RaceData.reversed); // setup waypoints
            var boatSetup = Instance.StartCoroutine(CreateBoats()); // spawn boats
            Coroutine uiSetup = null;

            switch (RaceData.game)
            {
                case GameType.Singleplayer:
                    uiSetup = Instance.StartCoroutine(CreatePlayerUi(0));
                    break;
                case GameType.LocalMultiplayer:
                    break;
                case GameType.Multiplayer:
                    break;
                case GameType.Spectator:
                    break;
                case GameType.Benchmark:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (scene.name.Contains("level") || scene.name.Contains("demo"))
            {
                Instance.StartCoroutine(BeginRace( new []{boatSetup, uiSetup})); // TODO need to make much better with race intro etc
            }
        }

        public static void SetGameType(GameType gameType)
        {
            RaceData.game = gameType;
            RaceData.boats = new List<BoatData>();
            Debug.Log($"Game type set to:{RaceData.game}");
            switch (RaceData.game)
            {
                case GameType.Singleplayer:
                    BoatData b = new BoatData();
                    b.human = false; //true; // TODO for testing
                    RaceData.boats.Add(b); // add player boat
                    GenerateRandomBoats(RaceData.boatCount - 1); // add random AI
                    break;
                case GameType.Spectator:
                    GenerateRandomBoats(RaceData.boatCount);
                    break;
            }
        }

        public static void SetLevel(int levelIndex)
        {
            RaceData.level = ConstantData.GetLevelName(levelIndex);
            Debug.Log($"Level set to:{levelIndex} with path:{RaceData.level}");
        }

        public static void SetHull(int player, int hull)
        {
            RaceData.boats[player].boatPrefab = Instance.boats[hull];
        }

        public static void LoadGame()
        {
            Application.backgroundLoadingPriority = ThreadPriority.Low;
            SceneManager.LoadSceneAsync(RaceData.level);
        }

        private static IEnumerator BeginRace(IEnumerable<Coroutine> loading)
        {
            foreach (var load in loading)
            {
                yield return load;
            }

            if(RaceData.game == GameType.Spectator) ReplayCamera.Instance.EnableSpectatorMode();

            yield return new WaitForSeconds(5f);

            RaceStarted = true;
        }

        private static void GenerateRandomBoats(int count, bool ai = true)
        {
            for (var i = 0; i < count; i++)
            {
                var boat = new BoatData();
                Random.InitState(ConstantData.SeedNow+i);
                boat.boatName = ConstantData.AiNames[Random.Range(0, ConstantData.AiNames.Length)];
                BoatLivery livery = new BoatLivery
                {
                    primaryColor = ConstantData.GetRandomPaletteColor,
                    trimColor = ConstantData.GetRandomPaletteColor
                };
                boat.livery = livery;
                boat.boatPrefab = Instance.boats[Random.Range(0, Instance.boats.Length)];

                if (ai)
                    boat.human = false;

                RaceData.boats.Add(boat);
            }
        }

        void LateUpdate()
        {
            if (RaceStarted)
            {
                for (int i = 0; i < RaceData.boats.Count; i++)
                {
                    var boat = RaceData.boats[i].Boat;
                    if (boat.MatchComplete)
                    {
                        _boatTimes[i] = boat.SplitTimes.Last();
                    }
                    else
                    {
                        _boatTimes[i] = boat.LapPercentage + boat.LapCount;
                    }
                }
                var mySortedList = _boatTimes.OrderBy(d => d.Value).ToList();
                mySortedList.Reverse();
                var place = 1;
                foreach (var index in mySortedList)
                {
                    RaceData.boats[index.Key].Boat.Place = place;
                    place++;
                }

                RaceTime += Time.deltaTime;
            }
        }

        public static int GetLapCount()
        {
            if (RaceData != null && RaceData.type == RaceType.Race)
            {
                return RaceData.laps;
            }
            return -1;
        }

        private static IEnumerator CreateBoats()
        {
            for (int i = 0; i < RaceData.boats.Count; i++)
            {
                var boat = RaceData.boats[i]; // boat to setup

                // Load prefab
                var startingPosition = WaypointGroup.Instance.StartingPositions[i];
                AsyncOperationHandle<GameObject> boatLoading = Addressables.InstantiateAsync(boat.boatPrefab, startingPosition.GetColumn(3),
                    Quaternion.LookRotation(startingPosition.GetColumn(2)));

                yield return boatLoading; // wait for boat asset to load

                boatLoading.Result.name = boat.boatName; // set the name of the boat
                boatLoading.Result.TryGetComponent<Boat>(out var boatController);
                boat.SetController(boatLoading.Result, boatController);
                boatController.Setup(i + 1, boat.human, boat.livery);
                Instance._boatTimes.Add(i, 0f);
            }

        }

        private static IEnumerator CreatePlayerUi(int player)
        {
            var uiLoading = Instance.raceUiPrefab.InstantiateAsync();
            yield return uiLoading;
            if (uiLoading.Result.TryGetComponent(out RaceUI uiComponent))
            {
                RaceData.boats[player].Boat.RaceUi = uiComponent;
                uiComponent.Setup(player);
            }
            // Setup race camera
            Camera.main.cullingMask |= 1 << LayerMask.NameToLayer($"Player{player + 1}");
        }
    }
}
