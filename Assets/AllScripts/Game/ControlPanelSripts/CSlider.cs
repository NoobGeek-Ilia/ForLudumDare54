using System;
using UnityEngine;
using UnityEngine.UI;

public class CSlider : MonoBehaviour
{
    public Slider[] sliders;
    private float[] sliderValues; // Массив для хранения значений слайдеров

    private void Start()
    {
        sliderValues = new float[sliders.Length]; // Инициализируем массив

        for (int i = 0; i < sliders.Length; i++)
        {
            int index = i; // Захватываем значение i в переменную index
            sliders[i].onValueChanged.AddListener((float value) => OnSliderValueChanged(index, value));
        }
    }

    void OnSliderValueChanged(int sliderIndex, float value)
    {
        sliderValues[sliderIndex] = value; // Сохраняем значение слайдера в массиве

        Debug.Log("Текущее значение слайдера " + sliderIndex + ": " + value);
    }
}
