using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace BoatAttack.UI
{
    public class RaceStatsPlayer : MonoBehaviour
    {

        public TextMeshProUGUI place;
        public TextMeshProUGUI playerName;
        public TextMeshProUGUI boatType;
        public TextMeshProUGUI bestLap;
        public TextMeshProUGUI time;
        private Boat _boat;
        private int _place = -1;
        private bool _update = true;

        public void Setup(Boat boat)
        {
            _boat = boat;
            playerName.text = _boat.name;
            boatType.text = "TODO"; // TODO - need to implement
        }

        private void Update()
        {
            if (!_update) return;
            UpdateStats();
        }

        private void LateUpdate()
        {
            _update = !_boat.MatchComplete;
        }

        public void UpdateStats()
        {
            _place = _boat.Place;
            transform.SetSiblingIndex(_place);
            place.text = OrdinalNumber(_boat.Place);

            var bestLapTime = BestLapFromSplitTimes(_boat.SplitTimes);
            bestLap.text = bestLapTime > 0 ? RaceUI.FormatRaceTime(bestLapTime) : "N/A";

            var totalTime = _boat.MatchComplete ? _boat.SplitTimes.Last() : RaceManager.RaceTime;
            time.text = RaceUI.FormatRaceTime(totalTime);
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
