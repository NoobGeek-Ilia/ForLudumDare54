using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class SSlider : MonoBehaviour
{
    public Slider[] sliders;
    internal protected static int[] sliderValues;

    private void Start()
    {
        sliders = GetComponentsInChildren<Slider>();
        sliderValues = new int[sliders.Length];
        for (int i = 0; i < sliders.Length; i++)
        {
            sliderValues[i] = 0;
        }
        SetStartValue();
    }

    void SetStartValue()
    {
        for (int i = 0; i < sliders.Length; i++)
        {
            int randomValue = Random.Range(0, (int)sliders[i].maxValue + 1);
            sliderValues[i] = randomValue;
            sliders[i].value = sliderValues[i];
        }
    }
}
