using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaxLodOption : MonoBehaviour {

    private int curlevel;
    public Text displayText;

    private void Start() {
        curlevel = (int)QualitySettings.lodBias;
        displayText.text = curlevel.ToString();
    }

	public void IncreaseLevel()
	{
		if(curlevel < 7)
            curlevel++;
        QualitySettings.lodBias = curlevel;
        displayText.text = curlevel.ToString();
    }

    public void DecreaseLevel()
    {
        if (curlevel > 0)
            curlevel--;
        QualitySettings.lodBias = curlevel;
        displayText.text = curlevel.ToString();
    }
}
