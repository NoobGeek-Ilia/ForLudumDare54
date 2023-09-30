using System;
using UnityEngine;
using UnityEngine.UI;

public class SSlider : MonoBehaviour
{
    public Slider[] sliders; // Изменили тип переменной на Slider
    private int currSliderIndex;

    private void Start()
    {
        foreach (Slider slider in sliders) // Изменили тип в цикле
        {
            slider.onValueChanged.AddListener((float value) => OnSliderValueChanged(slider, value)); // Используем onValueChanged для слайдера
        }
    }

    void OnSliderValueChanged(Slider currSlider, float value) // Изменили сигнатуру метода
    {
        currSliderIndex = Array.IndexOf(sliders, currSlider); // Заменили buttons на sliders
        Debug.Log("Текущее значение слайдера " + currSliderIndex + ": " + value);
    }
}
