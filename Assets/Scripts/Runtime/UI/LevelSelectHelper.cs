using BoatAttack;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelSelectHelper : MonoBehaviour
{
    [Header("Level Selection")]
    public Animator levelSelectAnimator;
    public LevelSelectOption[] levelUI;
    private static int currentLevel = 0;
    
    // Start is called before the first frame update
    public void Init()
    {
        PopulateLevelUI();
    }

    public void PopulateLevelUI()
    {
        var maxLevel = AppSettings.Instance.levels.Length;
        // make sure current level is within level count
        currentLevel = (int)Mathf.Repeat(currentLevel, maxLevel);
            
        for (int i = 0; i < 5; i++)
        {
            var level = (int)Mathf.Repeat(currentLevel + (i - 2), maxLevel);
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
        currentLevel++;
        Debug.Log("Next Level");
        levelSelectAnimator.SetTrigger("Next");
    }
        
    public void PrevLevel()
    {
        if (!levelSelectAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) return;
        currentLevel--;
        Debug.Log("Previous Level");
        levelSelectAnimator.SetTrigger("Prev");
    }
    
    public static void SetLevel() => RaceManager.SetLevel(currentLevel);

    private static void SetLaps(int index) => RaceManager.RaceData.laps = ConstantData.Laps[index];

    private static void SetReverse(int reverse) => RaceManager.RaceData.reversed = reverse == 1;

}
