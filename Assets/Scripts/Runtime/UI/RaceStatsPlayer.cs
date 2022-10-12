using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BoatAttack.UI
{
    public class RaceStatsPlayer : MonoBehaviour
    {
        [Header("Player Highlighting")] 
        public Image face;
        public Image outline;
        public Color playerFace;
        public Color otherFace;
        
        [Header("References")]
        public TextMeshProUGUI place;
        public PlayerMapMarker pmm;
        public TextMeshProUGUI playerName;
        public TextMeshProUGUI boatType;
        public TextMeshProUGUI bestLap;
        public TextMeshProUGUI time;
        
        private BoatData _boatData;
        private int _place = -1;
        private bool _update = true;

        public void Setup(BoatData boat, bool owner = false)
        {
            _boatData = boat;
            playerName.text = _boatData.playerName;
            boatType.text = boat.name;
            face.color = owner ? playerFace : otherFace;
            outline.color = owner ? Color.white : Color.black;
            pmm.Setup(boat);
        }

        private void Update()
        {
            if (!_update) return;
            UpdateStats();
        }

        private void LateUpdate()
        {
            _update = !_boatData.Boat.MatchComplete;
        }

        public void UpdateStats()
        {
            _place = _boatData.Boat.Place;
            transform.SetSiblingIndex(_place - 1);
            place.text = RaceUI.OrdinalNumber(_boatData.Boat.Place);

            var bestLapTime = RaceUI.BestLapFromSplitTimes(_boatData.Boat.SplitTimes);
            bestLap.text = bestLapTime > 0 ? RaceUI.FormatRaceTime(bestLapTime) : "N/A";

            var totalTime = _boatData.Boat.MatchComplete ? _boatData.Boat.SplitTimes.Last() : RaceManager.RaceTime;
            time.text = RaceUI.FormatRaceTime(totalTime);
        }
    }
}
