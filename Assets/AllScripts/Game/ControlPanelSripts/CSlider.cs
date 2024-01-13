using UnityEngine;
using UnityEngine.UI;

public class CSlider : MonoBehaviour
{
    internal protected static float[] sliderValues;

    private Slider[] sliders;

    internal protected void InitBoxButtons()
    {
        sliders = GetComponentsInChildren<Slider>();
        sliderValues = new float[sliders.Length];
        for (int i = 0; i < sliders.Length; i++)
        {
            int index = i;
            sliders[i].onValueChanged.AddListener((float value) => OnSliderValueChanged(index, value));
        }
    }

    private void OnSliderValueChanged(int sliderIndex, float value)
    {
        sliderValues[sliderIndex] = value;
        SoundManager.instance.PlaySFX("SliderButton");
    }
}