using UnityEngine;
using UnityEngine.UI;

public class SOnOffSwitch : MonoBehaviour
{
    private Button[] buttons; // Заменяем [SerializeField] на private
    private bool[] isActive;

    private void Start()
    {
        buttons = GetComponentsInChildren<Button>(); // Находим все кнопки в дочерних объектах
        isActive = new bool[buttons.Length];
        SetStartValue();
    }

    internal void SetStartValue()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            float value = Random.value;
            isActive[i] = value > 0.5f;
            if (isActive[i])
                buttons[i].image.color = Color.green;
            else
                buttons[i].image.color = Color.red;
        }
    }
}
