using UnityEngine;
using UnityEngine.UI;

public class SParameter : MonoBehaviour
{
    internal protected static bool[] isActive;

    private Toggle[] parameters;

    internal protected void InitBoxButtons()
    {
        parameters = GetComponentsInChildren<Toggle>();
        isActive = new bool[parameters.Length];
        SetStartValue();
    }
    private void SetStartValue()
    {
        for (int i = 0; i < parameters.Length; i++)
        {
            float value = Random.value;
            isActive[i] = value > 0.5f;
            parameters[i].isOn = value > 0.5f;
        }
    }
}