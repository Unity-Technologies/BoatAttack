using System.Collections;
using BoatAttack;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

[TestFixture]
public class InputTests
{
    private Mouse mouse;
    private Keyboard keyboard;
    private InputDevice[] devices;
    private InputTestFixture input = new();

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        // Store the current devices and then remove them so they don't interfere with the tests.
       devices = InputSystem.devices.ToArray();
       foreach (var device in InputSystem.devices)
       {
           // For some reason the array of devices might contain null values.
           if(device != null)
           {
               InputSystem.DisableDevice(device);
           }
       }
       // Register the input layout and register a mouse and keyboard so we can use them for our tests.
       InputSystem.RegisterLayout(TestUtility.GetLayout());
       keyboard = InputSystem.AddDevice<Keyboard>();
       mouse = InputSystem.AddDevice<Mouse>();
    }

    [SetUp]
    public void SetUp()
    {
        // The RaceManager is destroyed after each test, so we make sure to create a new one.
        if (RaceManager.Instance == null)
        {
            var appSettings = Resources.Load<GameObject>("AppSettings");
            Object.Instantiate(appSettings);
        }
    }

    [TearDown]
    public void TearDown()
    {
        // Destroy the RaceManager so we can create a fresh one for the next test.
        if (RaceManager.Instance != null)
        {
            RaceManager.Instance.StopAllCoroutines();
            Object.Destroy(RaceManager.Instance.gameObject);
        }
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        // Remove devices added during testing
        foreach (var device in InputSystem.devices)
        {
            if(device != null)
                InputSystem.RemoveDevice(device);
        }
        // Add devices which were removed during testing
        foreach (var device in devices)
        {
            if(device != null)
                InputSystem.EnableDevice(device);
        }
    }

    // This tests if the Forward movement works for the player.
    // It is a UnityTest since we need to yield instructions to wait and see if a player has moved after a period of 
    // time.
    [UnityTest]
    public IEnumerator WhenWKeyIsPressed_ThenBoatMovesForward()
    {
        // Boats only move with RaceState RaceStarted or RaceEnded.
        // If the state it RaceStarted, RaceManager will run some logic which requires several dependencies we don't want.
        RaceManager.State = RaceManager.RaceState.RaceEnded;

        // Spawn exactly 1 boat since we just care about testing player movement
        yield return TestUtility.SpawnBoats(1, true);
        
        // Store the boat's initial position so we can see if it moved
        var boatTransform = RaceManager.RaceData.boats[0].BoatObject.transform;
        var boatPos = boatTransform.position;
        
        // Hold down the W key to move forward
        input.Press(keyboard.wKey);
        // Wait 5 seconds to allow the boat to move
        yield return new WaitForSeconds(5);
        // Release the W key
        input.Release(keyboard.wKey);
        // Assert that we moved a certain distance to see that our input moved the boat
        var difference = Vector3.Distance(boatPos, boatTransform.position);
        Assert.Greater(difference, 20f);
    }
    
    // This test starts at the main menu and sees if the UI workflow to enter the game and start a race works as expected.
    // We test various cases to see if clicking through the UI fast causes any issues.
    [UnityTest]
    [TestCase(1f, ExpectedResult = null)]
    [TestCase(0.5f, ExpectedResult = null)]
    [TestCase(0.2f, ExpectedResult = null)]
    public IEnumerator CanEnterGameFromMainMenu(float waitBetweenButtonPresses)
    {
        // The scene we expect to be loaded after going through the main menu
        var expectedScene = "level_Island";

        // Load the main menu scene (We load it after since some scripts depend on there being a pointer/mouse present)
        yield return Addressables.LoadSceneAsync("Assets/scenes/main_menu.unity");
        
        // UI Buttons we want to interact with
        var playButton = GameObject.Find("MainMenuUI/Canvas/Main/Play");
        var singlePlayerButton = GameObject.Find("MainMenuUI/Canvas/Play/SinglePlayer");
        var levelButton = GameObject.Find("MainMenuUI/Canvas/LevelSelect/LevelCarousel/NextArrow");
        var boatButton = GameObject.Find("MainMenuUI/Canvas/Boat/Race");

        // Click through the UI to start the game
        ClickOnUIElement(playButton);
        yield return new WaitForSeconds(waitBetweenButtonPresses);
        ClickOnUIElement(singlePlayerButton);
        yield return new WaitForSeconds(waitBetweenButtonPresses);
        ClickOnUIElement(levelButton);
        yield return new WaitForSeconds(waitBetweenButtonPresses);
        ClickOnUIElement(boatButton);

        // This is the fastest way to make sure the scene is loaded, without waiting additional seconds
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == expectedScene);
        // Without this little wait the ReplayCameras class will throw an exception
        yield return new WaitForSeconds(1f);
        
        Assert.AreEqual(expectedScene, SceneManager.GetActiveScene().name);
    }
    
    // Find the position of a UI element so that we can set the mouse position and click on it.
    public void ClickOnUIElement(GameObject element)
    {
        var rect = element.GetComponent<RectTransform>();
        input.Set(mouse.position, rect.position);
        input.Click(mouse.leftButton);
    }
}
