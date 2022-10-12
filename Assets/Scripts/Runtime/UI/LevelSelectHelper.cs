using BoatAttack;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelSelectHelper : MonoBehaviour
{
    [Header("Level Selection")]
    public Animator levelSelectAnimator;
    public LevelSelectOption[] levelUI;

    private static int currentLevel = 0;

    private static int levelIndex
    {
        get => currentLevel;
        set => currentLevel = ValidateLevel(value);
    }

    private static int ValidateLevel(int index)
    {
        return (int) Mathf.Repeat(index, AppSettings.Instance.levels.Length);
    }

    public Button nextButton;
    
    // Start is called before the first frame update
    public void Init()
    {
        PopulateLevelUI();
    }

    public void PopulateLevelUI()
    {
            
        for (int i = 0; i < 5; i++)
        {
            var level = ValidateLevel(levelIndex + (i - 2));
            levelUI[i].PopulateData(AppSettings.Instance.levels[level]);
        }
            
        Canvas.ForceUpdateCanvases();
    }
    
    public void ChangeLevel(BaseEventData data)
    {
        var axisData = data as AxisEventData;

        switch (axisData!.moveDir)
        {
            case MoveDirection.Left:
                PrevLevel();
                break;
            case MoveDirection.Right:
                NextLevel();
                break;
        }
    }

    public void NextLevel()
    {
        if (!levelSelectAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) return;
        levelIndex++;
        CheckLevelAvailability();
        levelSelectAnimator.SetTrigger("Next");
    }
        
    public void PrevLevel()
    {
        if (!levelSelectAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) return;
        levelIndex--;
        CheckLevelAvailability();
        levelSelectAnimator.SetTrigger("Prev");
    }

    private void CheckLevelAvailability()
    {
        LevelData level = null;
        var levelAllowed = false;
        if (RaceManager.TryGetLevel(levelIndex, ref level))
        {
            levelAllowed = level.available;
        }
        nextButton.interactable = levelAllowed;
    }
    
    public static void SetLevel() => RaceManager.SetLevel(ref AppSettings.Instance.levels[levelIndex]);

    private static void SetLaps(int index) => RaceManager.RaceData.laps = ConstantData.Laps[index];

    private static void SetReverse(int reverse) => RaceManager.RaceData.reversed = reverse == 1;

}
