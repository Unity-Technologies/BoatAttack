using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectOption : MonoBehaviour
{
    [NonSerialized]public LevelData data;

    public TextMeshProUGUI levelName;
    public Image levelThumbnail;
    public TextMeshProUGUI levelDescription;
    public Sprite defaultThumb;

    // Start is called before the first frame update
    private void Start()
    {
        if (data)
        {
            PopulateData(data);
        }
    }

    public void PopulateData(LevelData data)
    {
        this.data = data;
        
        if (levelName)
            levelName.text = data.levelName;

        if (levelThumbnail)
            levelThumbnail.sprite = data.UIImage ? data.UIImage : defaultThumb;

        if (levelDescription)
            levelDescription.text = data.description;
    }
}
