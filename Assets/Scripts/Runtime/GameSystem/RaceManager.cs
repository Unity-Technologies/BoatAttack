using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using BoatAttack.UI;
using JetBrains.Annotations;
using UnityEngine.Playables;
using Random = UnityEngine.Random;

namespace BoatAttack
{
    public class RaceManager : MonoBehaviour
    {
        
        #region Enums
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
            public LevelData level;
            public int laps = 3;
            public bool reversed;

            //Competitors
            [NonSerialized] public List<BoatData> boats;
        }
        
        public enum RaceState
        {
            None,
            RaceLoaded,
            RaceStarted,
            RaceEnded,
        }
               
        #endregion
        
        public static RaceManager Instance;

        private static RaceState _state;
        public static RaceState State
        {
            get => _state;
            set
            {
                _state = value;
                StateChange?.Invoke(value);
            }
        }
        public static Action<RaceState> StateChange;

        [NonSerialized] public static Race RaceData;
        public Race demoRaceData = new Race();
        [NonSerialized] public static float RaceTime;
        private readonly Dictionary<int, float> _boatTimes = new Dictionary<int, float>();


        [Header("Assets")] private static BoatData[] Boats;
        public AssetReference raceUiPrefab;
        public AssetReference raceUiTouchPrefab;
        public AssetReference pauseMenuUiPrefab;
        
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
        
        private void Awake()
        {
            if(Debug.isDebugBuild)
                Debug.Log("RaceManager Loaded");
            Instance = this;
            
            // Load boat data from disk
            var boatSOs = Resources.LoadAll<BoatDataSO>("Data/Boat/");
            Boats = new BoatData[boatSOs.Length];
            for (var index = 0; index < boatSOs.Length; index++)
            {
                Boats[index] = boatSOs[index]._data;
            }
            
            AppSettings.Instance.input.BoatControl.Pause.performed += _ =>  TogglePauseState();
        }

        private void Reset()
        {
            State = RaceState.None;
            RaceTime = 0f;
            
            Utility.UnloadAssetReference(raceUiPrefab);
            Utility.UnloadAssetReference(raceUiTouchPrefab);
            Utility.UnloadAssetReference(pauseMenuUiPrefab);
            
            Instance._boatTimes?.Clear();
            CleanupBoats();
            //RaceData.boats.Clear(); // TODO check this
        }

        public static void Setup(Scene scene, LoadSceneMode mode)
        {
            Instance.StartCoroutine(SetupRace());
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public static IEnumerator SetupRace()
        {
            State = RaceState.RaceLoaded;
            
            Instance.StartCoroutine(LoadPauseMenu());

            if(RaceData == null) // make sure we have the data, otherwise default to demo data
            {
                RaceData = Instance.demoRaceData;
                RaceData.boats = new List<BoatData>();
                GenerateRandomBoats(4);
            }
            
            Debug.Log($"Setting up race:\n" +
                      $"{RaceData.game}:{RaceData.type}\n" +
                      $"{RaceData.level.levelName}:{RaceData.laps} Laps:Reversed {RaceData.reversed}\n" +
                      $"{RaceData.boats.Count} Boats");
            
            while (WaypointGroup.Instance == null) // TODO need to re-write whole game loading/race setup logic as it is dirty
            {
                yield return null;
            }
            WaypointGroup.Instance.Setup(RaceData.reversed); // setup waypoints
            yield return Instance.StartCoroutine(CreateBoats()); // spawn boats;

            switch (RaceData.game)
            {
                case GameType.Singleplayer:
                    yield return Instance.StartCoroutine(CreatePlayerUi(0));
                    SetupCamera(0); // setup camera for player 1
                    break;
                case GameType.LocalMultiplayer:
                    break;
                case GameType.Multiplayer:
                    break;
                case GameType.Spectator:
                    ReplayCamera.Instance.EnableSpectatorMode();
                    break;
                case GameType.Benchmark:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            Instance.StartCoroutine(BeginRace());
        }

        private static IEnumerator LoadPauseMenu()
        {
            if(!Instance.pauseMenuUiPrefab.OperationHandle.IsValid())
                Instance.pauseMenuUiPrefab.LoadAssetAsync<GameObject>();
            
            if (!Instance.pauseMenuUiPrefab.OperationHandle.IsDone) 
                yield return Instance.pauseMenuUiPrefab.OperationHandle;

            if (Instance.pauseMenuUiPrefab.OperationHandle.Status == AsyncOperationStatus.Succeeded)
            {
                var pauseObj = Instantiate((GameObject) Instance.pauseMenuUiPrefab.OperationHandle.Result);
                PauseMenuHelper.Instance = pauseObj.GetComponent<PauseMenuHelper>();
            }
            else
            {
                Debug.LogError("Pause menu failed to load.");
            }
        }
        
        public static void SetGameType(GameType gameType)
        {
            RaceData = new Race {game = gameType,
                boats = new List<BoatData>(),
                type = RaceType.Race
            };

            Debug.Log($"Game type set to:{RaceData.game}");
            switch (RaceData.game)
            {
                case GameType.Singleplayer:
                    var b = new BoatData(Boats[Random.Range(0, Boats.Length)])
                    {
                        playerName = "Player 1",
                        Human = true,
                    };
                    RaceData.boats.Add(b); // add player boat
                    GenerateRandomBoats(RaceData.boatCount - 1); // add random AI
                    break;
                case GameType.Spectator:
                    GenerateRandomBoats(RaceData.boatCount);
                    break;
                case GameType.LocalMultiplayer:
                    Debug.LogError("Not Implemented");
                    break;
                case GameType.Multiplayer:
                    Debug.LogError("Not Implemented");
                    break;
                case GameType.Benchmark:
                    Debug.LogError("Not Implemented");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static void SetLevel(ref LevelData level)
        {
            RaceData.level = level;
            Debug.Log($"Level set to:{level.levelName}");
        }

        public static bool TryGetLevel(int index, [CanBeNull] ref LevelData level)
        {
            if (AppSettings.Instance.levels.Length <= index) return false;
            level = AppSettings.Instance.levels[index];
            return true;
        }

        /// <summary>
        /// Triggered to begin the race
        /// </summary>
        /// <returns></returns>
        private static IEnumerator BeginRace()
        {
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
            
            State = RaceState.RaceStarted;
            
            SceneManager.sceneLoaded -= Setup;
        }

        /// <summary>
        /// Triggered when the race has finished
        /// </summary>
        private static void EndRace()
        {
            State = RaceState.RaceEnded;
            switch (RaceData.game)
            {
                case GameType.Spectator:
                    UnloadRace();
                    break;
                case GameType.Singleplayer:
                    SetupCamera(0, true);
                    break;
                case GameType.LocalMultiplayer:
                    break;
                case GameType.Multiplayer:
                    break;
                case GameType.Benchmark:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        private void LateUpdate()
        {
            if (State != RaceState.RaceStarted) return;

            var finished = 0;
            for (var i = 0; i < RaceData.boats.Count; i++)
            {
                var boat = RaceData.boats[i].Boat;
                if (boat.MatchComplete)
                {
                    _boatTimes[i] = Mathf.Infinity; // completed the race so no need to update
                    finished++;
                }
                else
                {
                    _boatTimes[i] = boat.LapPercentage + boat.LapCount;
                }
            }
            if(finished == RaceData.boatCount)
                EndRace();

            var mySortedList = _boatTimes.OrderBy(d => d.Value).ToList();
            var place = RaceData.boatCount;
            foreach (var boat in mySortedList.Select(index => RaceData.boats[index.Key].Boat).Where(boat => !boat.MatchComplete))
            {
                boat.Place = place;
                place--;
            }

            RaceTime += Time.deltaTime;
        }
        
        #region Utilities

        public static void LoadGame()
        {
            Debug.Log($"Loading Game level:{RaceData.level}");
            if(Instance) Instance.Reset();
            AppSettings.LoadLevel(RaceData.level);
            SceneManager.sceneLoaded += Setup;
        }

        public static void UnloadRace()
        {
            Debug.LogWarning("Unloading Race");
            Paused = false;
            Instance.Reset();
            AppSettings.LoadScene(1);
        }

        public static void TogglePauseState()
        {
            Paused = !Paused;
        }

        [NonSerialized]
        private static bool _paused;
        public static bool Paused
        {
            get => _paused;
            set
            {
                _paused = value;
                if (State == RaceState.RaceStarted)
                {
                    foreach (var bd in RaceData.boats.Where(bd =>
                                 bd.Boat != null && bd.Boat.RaceUi != null))
                    {
                        bd.Boat.RaceUi.SetGameplayUi(!value);
                    }
                }

                Time.timeScale = _paused ? 0f : 1f;
                KawaseBlur.KawasePass.Enabled = _paused;
                PauseMenuHelper.Instance.gameObject.SetActive(_paused);
            }
        }

        public static void SetHull(int player, BoatData data) => RaceData.boats[player] = data;
        
        private static IEnumerator CreateBoats()
        {
            for (int i = 0; i < RaceData.boats.Count; i++)
            {
                var boat = RaceData.boats[i]; // boat to setup

                // Load prefab
                var startingPosition = WaypointGroup.Instance.StartingPositions[i];
                var opHandle = Addressables.InstantiateAsync(boat.boatPrefab, startingPosition.GetColumn(3),
                    Quaternion.LookRotation(startingPosition.GetColumn(2)));

                if(!opHandle.IsDone)
                    yield return opHandle; // wait for boat asset to load

                var go = opHandle.Result;
                go.name = boat.playerName; // set the name of the boat
                go.TryGetComponent<Boat>(out var boatController);
                boat.SetController(go, boatController);
                boatController.Setup(i + 1, boat.Human, boat.Livery);
                Instance._boatTimes.Add(i, 0f);
            }
        }

        private static void CleanupBoats()
        {
            foreach (var data in FindObjectsOfType<Boat>())
            {
                Destroy(data.gameObject);
            }
        }
        
        private static void GenerateRandomBoats(int count, bool ai = true)
        {
            var names = ConstantData.AiNames.ToList();
            
            for (var i = 0; i < count; i++)
            {
                BoatData boat = new BoatData(Boats[Random.Range(0, Boats.Length)]);
                // get player name
                var n = Random.Range(0, names.Count);
                boat.playerName = names[n];
                names.RemoveAt(n);
                // get colors
                BoatLivery livery = new BoatLivery
                {
                    primaryColor = ConstantData.GetRandomPaletteColor,
                    trimColor = ConstantData.GetRandomPaletteColor
                };
                boat.Livery = livery;
                boat.boatPrefab = Boats[Random.Range(0, Boats.Length)].boatPrefab;

                if (ai)
                    boat.Human = false;

                RaceData.boats.Add(boat);
                Random.InitState(ConstantData.SeedNow+i*10);
            }
        }

        private static IEnumerator CreatePlayerUi(int player)
        {
            var touch = Input.touchSupported && 
                        Input.multiTouchEnabled &&
                        Application.platform is RuntimePlatform.Android or RuntimePlatform.IPhonePlayer;
            var uiAsset = touch ? Instance.raceUiTouchPrefab : Instance.raceUiPrefab;
            var opHandle = uiAsset.InstantiateAsync();
            
            if(!opHandle.IsDone)
                yield return opHandle;
            
            if (opHandle.Result.TryGetComponent(out RaceUI uiComponent))
            {
                var boatData = RaceData.boats[player];
                boatData.Boat.RaceUi = uiComponent;
                uiComponent.Setup(player);
            }
        }

        private static void SetupCamera(int player, bool remove = false)
        {
            if (AppSettings.MainCamera)
            {
                // Setup race camera
                if (remove)
                    AppSettings.MainCamera.cullingMask &=
                        ~(1 << LayerMask.NameToLayer(
                            $"Player{player + 1}")); // TODO - this needs more work for when adding splitscreen.
                else
                    AppSettings.MainCamera.cullingMask |=
                        1 << LayerMask.NameToLayer(
                            $"Player{player + 1}"); // TODO - this needs more work for when adding splitscreen.
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
        
        #endregion
    }
}
