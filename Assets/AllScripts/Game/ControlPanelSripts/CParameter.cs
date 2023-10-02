using UnityEngine;
using UnityEngine.UI;

public class CParameter : MonoBehaviour
{
    private Toggle[] parameters;
    internal protected static bool[] isActive;
    internal protected void InitBoxButtons()
    {
        parameters = GetComponentsInChildren<Toggle>();
        isActive = new bool[parameters.Length]; // Инициализируем массив

        SetStartValue();

        for (int i = 0; i < parameters.Length; i++)
        {
            Toggle param = parameters[i];
            int toggleIndex = i;
            param.onValueChanged.AddListener((value) => ToggleValueChanged(toggleIndex, value));
        }
    }

    private void SetStartValue()
    {
        for (int i = 0; i < parameters.Length; i++)
        {
            parameters[i].isOn = false; // Устанавливаем все Toggle в положение "выключено"
        }
    }

    private void ToggleValueChanged(int index, bool value)
    {
        isActive[index] = value;
        LogAllToggleStates();
    }

    private void LogAllToggleStates()
    {
        for (int i = 0; i < parameters.Length; i++)
        {
            string message = isActive[i] ? "включена" : "выключена";
            Debug.Log($"Ячейка {i}: галочка {message}");
        }
    }
}
