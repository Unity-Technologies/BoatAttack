using System;
using System.Collections;
using System.Collections.Generic;
using BoatAttack;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.TestTools;
using Object = UnityEngine.Object;

namespace Tests.CameraTests
{
    /// <summary>
    /// This class tests the actual implementation of the ReplayCamera. 
    /// </summary>
    public class ReplayCameraTests
    {
        // Store the path to the prefab so we can easily change them in the future.
        private const string ReplayCameraPath = "Assets/Objects/Levels/Island/ReplayCameras.prefab";

        // Store the actual game object of the replay camera so we can clean it up after each test.
        private GameObject _cameraObject;

        // The UnitySetUp attribute makes the method below run before each test.
        // Compared to a regular SetUp attribute it allows for yield statements, which lets us skip frames or wait for seconds.
        // Because we need to spawn game objects in our scene using addressables, we need to have it as a UnitySetUp
        // instead of a regular SetUp attribute.
        [UnitySetUp]
        public IEnumerator UnitySetUp()
        {
            // Asynchronously load the prefabs into memory using addressables.
            var cameraPrefab = Addressables.LoadAssetAsync<GameObject>(ReplayCameraPath);
        
            // Wait for the prefab to be loaded and then instantiate it
            yield return cameraPrefab;
        
            // Check if we loaded the prefab
            if(cameraPrefab.Status ==  AsyncOperationStatus.Failed)
            {
                throw new Exception("Camera Prefab could not be loaded");
            }
            
            // If we successfully loaded the prefab into memory, we instantiate it.
            _cameraObject = Object.Instantiate(cameraPrefab.Result);
            
            // Instantiate boats into our scene.
            yield return SpawnBoats();
        }


        // The TearDown attribute is run after each test.
        // This is where we will do our clean up to avoid leaving behind garbage and make our tests independent from each other
        [TearDown]
        public void TearDown()
        {
            // Since we create the camera for every test, we have to delete it for every test to avoid unexpected
            // behaviour between tests.
            Object.DestroyImmediate(_cameraObject);
            // The same goes for boats
            foreach (var boat in RaceManager.RaceData.boats)
            {
                Object.DestroyImmediate(boat.BoatObject);
            }
        }
    
        // We use the TestCase attribute to avoid writing multiple test methods which do the same thing.
        // It allows us to inject tbe values we define in the attributes into the method parameters.
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void SetTarget_WhenCorrectIndex_ThenSetsTargetToSpecifiedBoat(int boatIndex)
        {
            // We want to change the focus of the camera, to look at the boat at the given index.
            var expected = RaceManager.RaceData.boats[boatIndex].BoatObject.transform;
        
            // Use replay camera's SetTarget function to update the target of the clear shot camera.
            ReplayCamera.Instance.SetTarget(boatIndex);
        
            // The actual boat should be the clear shot camera's LookAt target
            var actual = ReplayCamera.Instance.clearShot.LookAt;
            // We expect the priority of the replay camera's clear shot to be 100, because the SetTarget method above
            // should change the priority to 100 if it works properly.
            Assert.AreEqual(100, ReplayCamera.Instance.clearShot.Priority);
            Assert.AreEqual(expected, actual);
        }

        // There are only 4 boats in a race, therefore trying to set the target to index 4 is out of bounds of the array.
        // We also test the lower bounds for out of range exception.
        [TestCase(4)]
        [TestCase(-1)]
        public void SetTarget_WhenTryingToLoadABoatNotPresent_ThenThrowsArgumentOutOfRangeException(int boatIndex)
        {
            // Assert that an exception is thrown on invalid boat indices.
            Assert.Throws<ArgumentOutOfRangeException>(() => ReplayCamera.Instance.SetTarget(boatIndex));
        }

        // Instantiate boats into the scene.
        private IEnumerator SpawnBoats()
        {
            // The method we are testing in this class is depending on there being boats in the scene
            // Therefore we need to spawn in a numbers of boats so we can test the method.
            // We spawn 4 boats since that is how many there are in a Boat Attack game.
            var boats = new List<BoatData>();
            for (var i = 0; i < 4; i++)
            {
                boats.Add(new BoatData
                    {
                        boatPrefab = new AssetReference("boat_interceptor"),
                        boatMesh =  new AssetReference("boat_interceptor_mesh")
                    }
                );
            }

            // Load in the boat prefabs and instantiate them.
            foreach (var boat in boats)
            {
                var boatLoading = Addressables.InstantiateAsync(boat.boatPrefab);
                yield return boatLoading;

                if (boatLoading.Status == AsyncOperationStatus.Failed)
                {
                    throw new Exception("The boat prefab could not be loaded");
                }
                // The SetController method sets the Boat and BoatObject variables of the Boat class
                // which are used to find component attached to the boats.
                boatLoading.Result.TryGetComponent<Boat>(out var boatController);
                boat.SetController(boatLoading.Result, boatController);
            }
        
            // The methods we are testing in this class depend on the RaceManager having a RaceData populated with boat adata
            // so we need to instantiate a new one and add the boats.
            var raceData = new RaceManager.Race
            {
                boats = boats
            };
            RaceManager.RaceData = raceData;
        }
    }
}