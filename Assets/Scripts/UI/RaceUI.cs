using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace BoatAttack.UI
{
    public class RaceUI : MonoBehaviour
    {
        private Boat _boat;
        public TextMeshProUGUI lapCounter;
        public TextMeshProUGUI positionNumber;
        public TextMeshProUGUI timeTotal;
        public TextMeshProUGUI timeLap;
        public TextMeshProUGUI speedText;
        public TextMeshProUGUI speedFormatText;

        public RectTransform map;
        public GameObject gameplayUi;
        public GameObject raceStat;

        [Header("Assets")]
        public AssetReference playerMarker;
        public AssetReference playerMapMarker;
        public AssetReference raceStatsPlayer;

        private int _playerIndex;
        private int _totalLaps;
        private int _totalPlayers;
        private float _timeOffset;
        private float _smoothedSpeed;
        private float _smoothSpeedVel;
        private AppSettings.SpeedFormat _speedFormat;
        private RaceStatsPlayer[] _raceStats;

        public void Setup(int player)
        {
            _playerIndex = player;
            _boat = RaceManager.RaceData.boats[_playerIndex].Boat;
            _totalLaps = RaceManager.GetLapCount();
            _totalPlayers = RaceManager.RaceData.boats.Count;
            _timeOffset = Time.time;

            switch (AppSettings.Instance.speedFormat)
            {
                case AppSettings.SpeedFormat._Kph:
                    _speedFormat = AppSettings.SpeedFormat._Kph;
                    speedFormatText.text = "kph";
                    break;
                case AppSettings.SpeedFormat._Mph:
                    _speedFormat = AppSettings.SpeedFormat._Mph;
                    speedFormatText.text = "mph";
                    break;
            }

            StartCoroutine(SetupPlayerMarkers(player));
            StartCoroutine(SetupPlayerMapMarkers());
            StartCoroutine(CreateGameStats());
        }

        public void Disable()
        {
            gameObject.SetActive(false);
        }

        public void SetGameplayUi(bool enable)
        {
            if (enable)
            {
                foreach (var stat in _raceStats)
                {
                    stat.UpdateStats();
                }
            }
            gameplayUi.SetActive(enable);
        }

        public void SetGameStats(bool enable)
        {
            raceStat.SetActive(enable);
        }

        private IEnumerator CreateGameStats()
        {
            _raceStats = new RaceStatsPlayer[RaceManager.RaceData.boatCount];
            for(var i = 0; i < RaceManager.RaceData.boatCount; i++)
            {
                var raceStatLoading = raceStatsPlayer.InstantiateAsync(raceStat.transform);
                yield return raceStatLoading;
                raceStatLoading.Result.name += RaceManager.RaceData.boats[i].boatName;
                raceStatLoading.Result.TryGetComponent(out _raceStats[i]);
                _raceStats[i].Setup(RaceManager.RaceData.boats[i].Boat);
            }
        }

        private IEnumerator SetupPlayerMarkers(int player)
        {
            for (int i = 0; i < RaceManager.RaceData.boats.Count; i++)
            {
                if (i == player) continue;

                var markerLoading = playerMarker.InstantiateAsync(gameplayUi.transform);
                yield return markerLoading; // wait for marker to load

                markerLoading.Result.name += RaceManager.RaceData.boats[i].boatName;
                if (markerLoading.Result.TryGetComponent<PlayerMarker>(out var pm))
                    pm.Setup(RaceManager.RaceData.boats[i]);
            }
        }

        private IEnumerator SetupPlayerMapMarkers()
        {
            foreach (var boatData in RaceManager.RaceData.boats)
            {
                var mapMarkerLoading = playerMapMarker.InstantiateAsync(map);
                yield return mapMarkerLoading; // wait for marker to load

                if (mapMarkerLoading.Result.TryGetComponent<PlayerMapMarker>(out var pm))
                    pm.Setup(boatData);
            }
        }

        public void UpdateLapCounter(int lap)
        {
            lapCounter.text = $"{lap}/{_totalLaps}";
        }

        public void UpdatePlaceCounter(int place)
        {
            positionNumber.text = $"{place}/{_totalPlayers}";
        }

        public void UpdateSpeed(float velocity)
        {
            var speed = 0f;

            switch (_speedFormat)
            {
                case AppSettings.SpeedFormat._Kph:
                    speed = velocity * 3.6f;
                    break;
                case AppSettings.SpeedFormat._Mph:
                    speed = velocity * 2.23694f;
                    break;
            }

            _smoothedSpeed = Mathf.SmoothDamp(_smoothedSpeed, speed, ref _smoothSpeedVel, 1f);
            speedText.text = _smoothedSpeed.ToString("000");
        }

        public void LateUpdate()
        {
            var rawTime = RaceManager.RaceTime;
            timeTotal.text = $"time {FormatRaceTime(rawTime)}";

            var l = (_boat.SplitTimes.Count > 0) ? rawTime - _boat.SplitTimes[_boat.LapCount - 1] : 0f;
            timeLap.text = $"lap {FormatRaceTime(l)}";
        }

        public static string FormatRaceTime(float seconds)
        {
            var t = TimeSpan.FromSeconds(seconds);
            return $"{t.Minutes:D2}:{t.Seconds:D2}.{t.Milliseconds:D3}";
        }
    }
}
