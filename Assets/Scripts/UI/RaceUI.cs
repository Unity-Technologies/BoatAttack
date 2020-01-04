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
        public AssetReference playerMarkerPrefab;

        private int _playerIndex;
        private int _totalLaps;
        private int _totalPlayers;
        private float _timeOffset;
        private float _smoothedSpeed;
        private float _smoothSpeedVel;
        private AppSettings.SpeedFormat _speedFormat;

        public void Setup(int player)
        {
            _playerIndex = player;
            var manager = RaceManager.Instance;
            _boat = manager.raceData.boats[_playerIndex].Boat;
            _totalLaps = manager.GetLapCount();
            _totalPlayers = manager.raceData.boats.Count;
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
        }

        IEnumerator SetupPlayerMarkers(int player)
        {
            for (int i = 0; i < RaceManager.Instance.raceData.boats.Count; i++)
            {
                if (i == player) continue;
                
                var markerLoading = playerMarkerPrefab.InstantiateAsync(transform);
                yield return markerLoading; // wait for marker to load
                
                if (markerLoading.Result.TryGetComponent<PlayerMarker>(out var pm))
                    pm.Setup(RaceManager.Instance.raceData.boats[i]);
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
            var t = TimeSpan.FromSeconds(_boat.TotalTime);
            timeTotal.text = $"time {t.Minutes:D2}:{t.Seconds:D2}.{t.Milliseconds:D3}";

            var l = _boat.TotalTime;
            if (_boat.LapCount > 1)
                l -= _boat.SplitTimes[_boat.LapCount - 2];
            var lt = TimeSpan.FromSeconds(l);
            timeLap.text = $"lap +{lt.Minutes:D2}:{lt.Seconds:D2}.{lt.Milliseconds:D3}";
        }
    }
}
