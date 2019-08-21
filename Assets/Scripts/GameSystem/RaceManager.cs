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
		public GameObject humanBoat;
		public GameObject aiBoat;

        private void OnEnable()
        {
            WaypointGroup.Instance.reverse = raceData.reversed;
            WaypointGroup.Instance.Setup();
            CreateBoats();
        }

        private void CreateBoats()
        {
            var i = 0;
            foreach (var boat in raceData.boats)
            {
                var matrix = WaypointGroup.Instance.startingPositons[i];
				
                GameObject boatObject = Instantiate(boat.Human ? humanBoat : aiBoat, matrix.GetColumn(3), Quaternion.LookRotation(matrix.GetColumn(2))) as GameObject;
                boatObject.name = boat.boatName;
                BoatController boatController = boatObject.GetComponent<BoatController>();
                boatController.cam.gameObject.layer = LayerMask.NameToLayer("Player" + (i + 1));
                i++;
            }
        }
    }
}
