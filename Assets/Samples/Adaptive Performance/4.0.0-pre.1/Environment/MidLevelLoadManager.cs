using UnityEngine;

public class MidLevelLoadManager : MonoBehaviour
{
    [Tooltip("How many Vegetation objects in percent(%) to enable at the start of the test(DISABLED)")]
    [Range(0, 100)]
    public float startingLoadAmount = 100;

    public Transform Vegetation;

    public void SetLoad(float loadAmount)
    {
        startingLoadAmount = loadAmount;
        foreach (Transform veg in Vegetation)
        {
            veg.gameObject.SetActive(false);
        }
        int vegetationCount = Vegetation.childCount;
        int percentageAmount = Mathf.FloorToInt((vegetationCount / 100.0f) * loadAmount);
        for (int i = 0; i < percentageAmount; i++)
        {
            Vegetation.GetChild(i).gameObject.SetActive(true);
        }
    }
}
