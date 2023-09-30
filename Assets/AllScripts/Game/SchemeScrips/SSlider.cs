using UnityEngine;
using UnityEngine.UI;

public class SSlider : MonoBehaviour
{
    public Slider[] sliders;
    private int[] sliderValues; // Изменил тип на int

    private void Start()
    {
        SetStartValue();
    }

    void SetStartValue()
    {
        sliderValues = new int[sliders.Length]; // Инициализируем массив

        for (int i = 0; i < sliders.Length; i++)
        {
            int randomValue = Random.Range(0, (int)sliders[i].maxValue + 1); // Генерируем случайное целое значение от 0 до максимального значения слайдера
            sliderValues[i] = randomValue;
            sliders[i].value = sliderValues[i];
        }
    }
}
