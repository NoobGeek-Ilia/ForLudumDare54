using UnityEngine;
using UnityEngine.UI;

public class CParameter : MonoBehaviour
{
    internal protected static bool[] isActive;

    private Toggle[] parameters;

    internal protected void InitBoxButtons()
    {
        parameters = GetComponentsInChildren<Toggle>();
        isActive = new bool[parameters.Length];

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
        SoundManager.instance.PlaySFX("ParameterButton");
    }

    private void LogAllToggleStates()
    {
        for (int i = 0; i < parameters.Length; i++)
        {
            string message = isActive[i] ? "включена" : "выключена";
        }
    }
}