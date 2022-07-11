using UnityEngine;
using UnityEngine.UI;

public class MaxLodOption : MonoBehaviour {

    private int _currentLevel;
    public Text displayText;

    private void Start() {
        _currentLevel = (int)QualitySettings.lodBias;
        displayText.text = _currentLevel.ToString();
    }

	public void IncreaseLevel()
	{
		if(_currentLevel < 7)
            _currentLevel++;
        QualitySettings.lodBias = _currentLevel;
        displayText.text = _currentLevel.ToString();
    }

    public void DecreaseLevel()
    {
        if (_currentLevel > 0)
            _currentLevel--;
        QualitySettings.lodBias = _currentLevel;
        displayText.text = _currentLevel.ToString();
    }
}
