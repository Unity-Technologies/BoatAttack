using TMPro;
using UnityEngine;

namespace BoatAttack.UI
{
    public class EnumSelector : MonoBehaviour
    {
        public string[] options;
        public TextMeshProUGUI text;
        public bool loop;
        public int startOption;
        private int _currentOption;

        public delegate void UpdateValue(int index);

        public UpdateValue updateVal;

        private void ValueUpdate(int i)
        {
            updateVal?.Invoke(i);
        }

        private void Awake()
        {
            _currentOption = startOption;
            UpdateText();
        }

        public void NextOption()
        {
            _currentOption = ValidateIndex(_currentOption + 1);
            UpdateText();
            ValueUpdate(_currentOption);
        }

        public void PreviousOption()
        {
            _currentOption = ValidateIndex(_currentOption - 1);
            UpdateText();
            ValueUpdate(_currentOption);
        }

        public int CurrentOption
        {
            get => _currentOption;
            set
            {
                _currentOption = ValidateIndex(value);
                UpdateText();
                ValueUpdate(_currentOption);
            }
        }

        private void UpdateText()
        {
            text.text = options[_currentOption];
        }

        private int ValidateIndex(int index)
        {
            if (loop)
            {
                return (int) Mathf.Repeat(index, options.Length);
            }

            return Mathf.Clamp(index, 0, options.Length);
        }
    }
}