using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using BoatAttack.UI;
using UnityEngine.Playables;
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
        [NonSerialized] public static bool RaceStarted = false;
        [NonSerialized] public static Race RaceData = null;
		[FormerlySerializedAs("raceData")]
        public Race demoRaceData = new Race();
        [NonSerialized] public static float RaceTime;
        private readonly Dictionary<int, float> _boatTimes = new Dictionary<int, float>();

        public static Action<bool> raceStarted;

        private static void StartRace(bool started)
        {
            var a = RaceManager.raceStarted;
            if (a == null) return;
            RaceStarted = started;
            a(started);
        }

        public static void BoatFinished(int player)
        {
            switch (RaceData.game)
            {
                case GameType.Singleplayer:
                    if (player == 0)
                    {
                        var raceUi = RaceData.boats[0].Boat.RaceUi;
                        raceUi.MatchEnd();
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
        public AssetReference raceUiTouchPrefab;

        private void OnEnable()
        {
            Instance = this;
            SceneManager.sceneLoaded += SetupRace;
            SceneManager.sceneUnloaded += UnloadRace;
            SetupRace(SceneManager.GetActiveScene(), LoadSceneMode.Single);
        }

        private void Reset()
        {
            RaceStarted = false;
            RaceData.boats = null;
            RaceTime = 0f;
            _boatTimes.Clear();
        }

        private static void SetupRace(Scene scene, LoadSceneMode mode)
        {
            if (!scene.name.Contains("level") && !scene.name.Contains("demo")) return;
            if(RaceData == null) RaceData = Instance.demoRaceData;
            Instance.StartCoroutine(SetupRaceObjects());
        }

        private static IEnumerator SetupRaceObjects()
        {
            WaypointGroup.Instance.Setup(RaceData.reversed); // setup waypoints
            yield return Instance.StartCoroutine(CreateBoats()); // spawn boats;

            switch (RaceData.game)
            {
                case GameType.Singleplayer:
                    yield return Instance.StartCoroutine(CreatePlayerUi(0));
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
            Instance.StartCoroutine(BeginRace());
        }

        private static void UnloadRace(Scene scene)
        {
            if(!RaceStarted) return;
            Debug.LogWarning("Unloading Race");
            Instance.Reset();
            Instance.raceUiPrefab.ReleaseAsset();
        }

        public static void SetGameType(GameType gameType)
        {
            RaceData = new Race {game = gameType,
                boats = new List<BoatData>(),
                boatCount = 4,
                laps = 3,
                type = RaceType.Race
            };

            Debug.Log($"Game type set to:{RaceData.game}");
            switch (RaceData.game)
            {
                case GameType.Singleplayer:
                    var b = new BoatData();
                    b.human = true; // single player is human
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
            AppSettings.LoadScene(RaceData.level);
        }

        private static IEnumerator BeginRace()
        {
            if (RaceData.game == GameType.Spectator)
            {
                ReplayCamera.Instance.EnableSpectatorMode();
            }

            var introCams = GameObject.FindWithTag("introCameras");
            introCams.TryGetComponent<PlayableDirector>(out var introDirector);

            if (introDirector)
            {
                while (introDirector.state == PlayState.Playing)
                {
                    yield return null;
                }
                introCams.SetActive(false);
            }

            yield return new WaitForSeconds(3f); // countdown 3..2..1..

            StartRace(true);
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

        private void LateUpdate()
        {
            if (RaceStarted)
            {
                for (int i = 0; i < RaceData.boats.Count; i++)
                {
                    var boat = RaceData.boats[i].Boat;
                    if (boat.MatchComplete)
                    {
                        _boatTimes[i] = Mathf.Infinity; // completed the race so no need to update
                    }
                    else
                    {
                        _boatTimes[i] = boat.LapPercentage + boat.LapCount;
                    }
                }
                var mySortedList = _boatTimes.OrderBy(d => d.Value).ToList();
                var place = RaceData.boatCount;
                foreach (var boat in mySortedList.Select(index => RaceData.boats[index.Key].Boat).Where(boat => !boat.MatchComplete))
                {
                    boat.Place = place;
                    place--;
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
            var touch = Input.touchSupported && Input.multiTouchEnabled &&
                        (Application.platform == RuntimePlatform.Android ||
                         Application.platform == RuntimePlatform.IPhonePlayer);
            var uiAsset = touch ? Instance.raceUiTouchPrefab : Instance.raceUiPrefab;
            var uiLoading = uiAsset.InstantiateAsync();
            yield return uiLoading;
            if (uiLoading.Result.TryGetComponent(out RaceUI uiComponent))
            {
                var boatData = RaceData.boats[player];
                boatData.Boat.RaceUi = uiComponent;
                uiComponent.Setup(player);
            }
            // Setup race camera
            AppSettings.MainCamera.cullingMask |= 1 << LayerMask.NameToLayer($"Player{player + 1}");
        }
    }
}
