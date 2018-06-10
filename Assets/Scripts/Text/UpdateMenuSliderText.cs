using UnityEngine;
using UnityEngine.UI;

public class UpdateMenuSliderText : MonoBehaviour
{
    private Text _sliderValue;

	private void Awake ()
    {
        _sliderValue = GetComponent<Text>();
	}
	
	public void TextUpdate(float value)
    {
        _sliderValue.text = ((int)value).ToString();
    }
}
