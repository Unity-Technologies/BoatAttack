using System;
using System.Collections.Generic;
using BoatAttack.Boat;
using Cinemachine;
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
        private GameObject[] boats;

        public CinemachineVirtualCamera DroneCamera;
        
        private void Start()
        {
            WaypointGroup.instance.reverse = raceData.reversed;
            WaypointGroup.instance.Setup();
            CreateBoats();
            DroneCameraTrack(0);
        }

        private void CreateBoats()
        {
            boats = new GameObject[raceData.boats.Count];
            var i = 0;
            foreach (var boat in raceData.boats)
            {
                var matrix = WaypointGroup.instance.startingPositons[i];

                GameObject boatObject = Instantiate(boat.boatPrefab, matrix.GetColumn(3), Quaternion.LookRotation(matrix.GetColumn(2))) as GameObject;
                boatObject.name = boat.boatName;
                BoatController boatController = boatObject.GetComponent<BoatController>();
                boatController.Human = boat.Human;
                boatController.cam.gameObject.layer = LayerMask.NameToLayer("Player" + (i + 1));
                boats[i] = boatObject;
                i++;
            }
        }

        void DroneCameraTrack(int player)
        {
            DroneCamera.Follow = boats[player].transform;
            DroneCamera.LookAt = boats[player].transform;
        }
	}
}
