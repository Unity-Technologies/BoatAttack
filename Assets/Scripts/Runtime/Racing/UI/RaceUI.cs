using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace BoatAttack.UI
{
    public class RaceUI : MonoBehaviour
    {
        [Header("Gameplay")]
        public TextMeshProUGUI lapCounter;
        public TextMeshProUGUI timeTotal;
        public TextMeshProUGUI timeLap;
        public TextMeshProUGUI timeLapText;
        public TextMeshProUGUI speedText;

        public RectTransform playerList;
        public RectTransform map;
        public GameObject gameplayUi;
        
        [Header("Match End Screen")]
        public GameObject raceStat;
        public RectTransform statsContainer;
        public GameObject matchEnd;

        [Header("Assets")]
        public AssetReference playerMarker;
        public AssetReference playerMapMarker;
        public AssetReference raceStatsPlayer;
        public AssetReference playerPlace;
        
        private Boat _boat;
        private Canvas _canvas;
        private int _playerIndex;
        private int _totalLaps;
        private float _timeOffset;
        private float _smoothedSpeed;
        private float _smoothSpeedVel;
        private AppSettings.SpeedFormat _speedFormat;
        private RaceStatsPlayer[] _raceStats;

        private void Start()
        {
            RaceManager.StateChange += RaceStateChange;
            TryGetComponent(out _canvas);
        }

        private void OnDestroy()
        {
            RaceManager.StateChange -= RaceStateChange;
        }

        private void RaceStateChange(RaceManager.RaceState state)
        {
            SetGameplayUi(state is RaceManager.RaceState.RaceStarted or RaceManager.RaceState.RaceLoaded);
        }

        public void Setup(int player)
        {
            _playerIndex = player;
            _boat = RaceManager.RaceData.boats[_playerIndex].Boat;
            _totalLaps = RaceManager.GetLapCount();
            _timeOffset = Time.time;
            
            StartCoroutine(SetupPlayerMarkers(player));
            StartCoroutine(SetupPlayerMapMarkers(player));
            StartCoroutine(CreateGameStats(player));
            StartCoroutine(SetupPlayerList(player));
        }
        
        public void SetCanvas(bool enable)
        {
            if (_canvas && _canvas.enabled != enable)
            {
                _canvas.enabled = enable;
            }
        }

        public void SetGameplayUi(bool state)
        {
            gameplayUi.SetActive(state);

            if (!state) return;
            
            foreach (var stat in _raceStats)
            {
                stat.UpdateStats();
            }
        }
        
        public void MatchEnd()
        {
            matchEnd.SetActive(true);
            SetGameStats(true);
            SetGameplayUi(false);
        }
        
        public void SetGameStats(bool enable)
        {
            raceStat.SetActive(enable);
        }

        private IEnumerator CreateGameStats(int player)
        {
            _raceStats = new RaceStatsPlayer[RaceManager.RaceData.boatCount];
            for(var i = 0; i < RaceManager.RaceData.boatCount; i++)
            {
                var raceStatLoading = raceStatsPlayer.InstantiateAsync(statsContainer);
                yield return raceStatLoading;
                raceStatLoading.Result.name += RaceManager.RaceData.boats[i].name;
                raceStatLoading.Result.TryGetComponent(out _raceStats[i]);
                _raceStats[i].Setup(RaceManager.RaceData.boats[i], i == player);
            }
        }

        private IEnumerator SetupPlayerMarkers(int player)
        {
            for (int i = 0; i < RaceManager.RaceData.boats.Count; i++)
            {
                if (i == player) continue;

                var markerLoading = playerMarker.InstantiateAsync(gameplayUi.transform);
                yield return markerLoading; // wait for marker to load

                if (markerLoading.Result.TryGetComponent<PlayerMarker>(out var pm))
                    pm.Setup(RaceManager.RaceData.boats[i]);
            }
        }

        private IEnumerator SetupPlayerMapMarkers(int player)
        {
            foreach (var boatData in RaceManager.RaceData.boats)
            {
                var mapMarkerLoading = playerMapMarker.InstantiateAsync(map);
                yield return mapMarkerLoading; // wait for marker to load

                if (mapMarkerLoading.Result.TryGetComponent<PlayerMapMarker>(out var pm))
                    pm.Setup(boatData);
            }
        }
        
        private IEnumerator SetupPlayerList(int player)
        {
            for(var i = 0; i < RaceManager.RaceData.boatCount; i++)
            {
                var playerPlaceLoader = playerPlace.InstantiateAsync(playerList);
                yield return playerPlaceLoader; // wait for marker to load

                if (playerPlaceLoader.Result.TryGetComponent<PlayerListEntry>(out var ple))
                    ple.Setup(RaceManager.RaceData.boats[i], i == player);
            }
        }

        public void UpdateLapCounter(int lap)
        {
            lapCounter.text = $"Lap {lap}/{_totalLaps}";

            if (lap == 1) return;
            
            if (_boat.SplitTimes.Count > 1)
            {
                if (_boat.SplitTimes[lap - 1] <= BestLapFromSplitTimes(_boat.SplitTimes) + float.Epsilon)
                    timeLapText.color = Color.white;
            }
            
            timeLap.text = $"Split {FormatRaceTime(_boat.SplitTimes[lap - 1])}";
            timeLap.color = Color.white;
        }

        public void UpdateSpeed(float velocity)
        {
            var speed = 0f;
            var speedExt = "n/a";

            switch (_speedFormat)
            {
                case AppSettings.SpeedFormat._Kph:
                    speed = velocity * 3.6f;
                    speedExt = "kph";
                    break;
                case AppSettings.SpeedFormat._Mph:
                    speed = velocity * 2.23694f;
                    speedExt = "mph";
                    break;
            }

            _smoothedSpeed = Mathf.SmoothDamp(_smoothedSpeed, speed, ref _smoothSpeedVel, 1f);
            speedText.text = $"Speed: {_smoothedSpeed:F0}{speedExt}";
        }

        public void FinishMatch()
        {
            RaceManager.UnloadRace();
        }

        public void LateUpdate()
        {
            var rawTime = RaceManager.RaceTime;
            timeTotal.text = $"Time: {FormatRaceTime(rawTime, false)}";

            if (timeLap.color.a > 0f)
            {
                var col = timeLap.color;
                col.a -= Time.deltaTime * 0.25f;
                timeLap.color = col;
            }
            
            if (timeLapText.color.a > 0f)
            {
                var col = timeLapText.color;
                col.a -= Time.deltaTime * 0.25f;
                timeLapText.color = col;
            }
            
            if(FreeCam.Instance)
                SetCanvas(!FreeCam.Instance.active);
        }

        public static string FormatRaceTime(float seconds, bool fine = true)
        {
            var t = TimeSpan.FromSeconds(seconds);

            if (fine)
            {
                return $"{t.Minutes:D2}:{t.Seconds:D2}.{t.Milliseconds:D3}";
            }
            else
            {
                var ms = Mathf.Floor(t.Milliseconds / 100.0f);
                return $"{t.Minutes:D2}:{t.Seconds:D2}.{ms}";
            }
        }

        public static string OrdinalNumber(int num)
        {
            var number = num.ToString();
            if (number.EndsWith("11")) return $"{number}th";
            if (number.EndsWith("12")) return $"{number}th";
            if (number.EndsWith("13")) return $"{number}th";
            if (number.EndsWith("1")) return $"{number}st";
            if (number.EndsWith("2")) return $"{number}nd";
            if (number.EndsWith("3")) return $"{number}rd";
            return $"{number}th";
        }

        public static float BestLapFromSplitTimes(List<float> splits)
        {
            // ignore 0 as it's the beginning of the race
            if (splits.Count <= 1) return 0;
            var fastestLap = Mathf.Infinity;

            for (var i = 1; i < splits.Count; i++)
            {
                var lap = splits[i] - splits[i - 1];
                fastestLap = lap < fastestLap ? lap : fastestLap;
            }
            return fastestLap;
        }
    }
}
