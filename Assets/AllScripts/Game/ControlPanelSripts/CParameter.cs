using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CParameter : MonoBehaviour
{
    Toggle[] parameters;
    private bool[] isActive;

    void Start()
    {
        parameters = GetComponentsInChildren<Toggle>();
        isActive = new bool[parameters.Length]; // �������������� ������

        SetStartValue();

        for (int i = 0; i < parameters.Length; i++)
        {
            Toggle param = parameters[i];
            int toggleIndex = i;
            param.onValueChanged.AddListener((value) => ToggleValueChanged(toggleIndex, value));
        }
    }

    void SetStartValue()
    {
        for (int i = 0; i < parameters.Length; i++)
        {
            parameters[i].isOn = false; // ������������� ��� Toggle � ��������� "���������"
        }
    }

    void ToggleValueChanged(int index, bool value)
    {
        isActive[index] = value;
        LogAllToggleStates();
    }

    void LogAllToggleStates()
    {
        for (int i = 0; i < parameters.Length; i++)
        {
            string message = isActive[i] ? "��������" : "���������";
            Debug.Log($"������ {i}: ������� {message}");
        }
    }
}
