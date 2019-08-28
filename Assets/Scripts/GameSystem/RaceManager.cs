using System;
using System.Collections;
using System.Collections.Generic;
using BoatAttack.Boat;
using UnityEngine;
using WaterSystem;

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

		public bool useDOTS;
		public GameObject humanBoat;
		public GameObject aiBoat;

		public Race raceData;

        private void Start()
        {
            WaypointGroup.instance.reverse = raceData.reversed;
            WaypointGroup.instance.Setup();
            CreateBoats();
        }

        private void CreateBoats()
        {
			if (useDOTS)
			{
				CreateBoats_DOTS();
				return;
			}

            var i = 0;
            foreach (var boat in raceData.boats)
            {
                var matrix = WaypointGroup.instance.startingPositons[i];

                GameObject boatObject = Instantiate(boat.boatPrefab, matrix.GetColumn(3), Quaternion.LookRotation(matrix.GetColumn(2))) as GameObject;
                boatObject.name = boat.boatName;
                BoatController boatController = boatObject.GetComponent<BoatController>();
                boatController.Human = boat.Human;
                boatController.cam.gameObject.layer = LayerMask.NameToLayer("Player" + (i + 1));
                i++;
            }
        }

		private void CreateBoats_DOTS()
		{
			var i = 0;
			foreach (var boat in raceData.boats)
			{
				var matrix = WaypointGroup.instance.startingPositons[i];

				var prefab = boat.Human ? humanBoat : aiBoat;

				GameObject entityObj = Instantiate(prefab, matrix.GetColumn(3), Quaternion.LookRotation(matrix.GetColumn(2))) as GameObject;
				GameObject boatObject = entityObj.GetComponent<BuoyantObject_DOTS>().childObject;

				boatObject.name = boat.boatName;
				BoatController boatController = boatObject.GetComponent<BoatController>();
				boatController.cam.gameObject.layer = LayerMask.NameToLayer("Player" + (i + 1));
				i++;
			}
		}
	}
}
