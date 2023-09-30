using UnityEngine;
using UnityEngine.UI;

public class CSlider : MonoBehaviour
{
    private Slider[] sliders;
    private float[] sliderValues;

    private void Start()
    {
        // ������ ��� �������� � ������������ �������
        sliders = GetComponentsInChildren<Slider>();

        sliderValues = new float[sliders.Length];

        for (int i = 0; i < sliders.Length; i++)
        {
            int index = i;
            sliders[i].onValueChanged.AddListener((float value) => OnSliderValueChanged(index, value));
        }
    }

    void OnSliderValueChanged(int sliderIndex, float value)
    {
        sliderValues[sliderIndex] = value;

        Debug.Log("������� �������� �������� " + sliderIndex + ": " + value);
    }
}
