using UnityEngine;
using UnityEngine.UI;

public class SSlider : MonoBehaviour
{
    public Slider[] sliders;
    private int[] sliderValues; // ������� ��� �� int

    private void Start()
    {
        SetStartValue();
    }

    void SetStartValue()
    {
        sliderValues = new int[sliders.Length]; // �������������� ������

        for (int i = 0; i < sliders.Length; i++)
        {
            int randomValue = Random.Range(0, (int)sliders[i].maxValue + 1); // ���������� ��������� ����� �������� �� 0 �� ������������� �������� ��������
            sliderValues[i] = randomValue;
            sliders[i].value = sliderValues[i];
        }
    }
}
