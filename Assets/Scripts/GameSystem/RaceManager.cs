using System;
using System.Collections;
using System.Collections.Generic;
using BoatAttack.Boat;
using UnityEngine;

namespace BoatAttack
{
    public class RaceManager : MonoBehaviour
    {
        [Serializable]
        public class Race
        {
            public List<BoatData> boats;
            public int laps = 3;
            public bool reversed;
        }

        public Race raceData;

        private void OnEnable()
        {
            WaypointGroup.Instance.reverse = raceData.reversed;
            CreateBoats();
        }

        private void CreateBoats()
        {
            var i = 0;
            foreach (var boat in raceData.boats)
            {
                var matrix = WaypointGroup.Instance.startingPositons[i];

                GameObject boatObject = Instantiate(boat.boatPrefab, matrix.GetColumn(3), Quaternion.LookRotation(matrix.GetColumn(2))) as GameObject;

                i++;
            }
        }
    }
}
