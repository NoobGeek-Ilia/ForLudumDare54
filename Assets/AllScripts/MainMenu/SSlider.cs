using System;
using UnityEngine;
using UnityEngine.UI;

public class SSlider : MonoBehaviour
{
    public Slider[] sliders; // �������� ��� ���������� �� Slider
    private int currSliderIndex;

    private void Start()
    {
        foreach (Slider slider in sliders) // �������� ��� � �����
        {
            slider.onValueChanged.AddListener((float value) => OnSliderValueChanged(slider, value)); // ���������� onValueChanged ��� ��������
        }
    }

    void OnSliderValueChanged(Slider currSlider, float value) // �������� ��������� ������
    {
        currSliderIndex = Array.IndexOf(sliders, currSlider); // �������� buttons �� sliders
        Debug.Log("������� �������� �������� " + currSliderIndex + ": " + value);
    }
}
