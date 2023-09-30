using UnityEngine;
using UnityEngine.UI;

public class SParameter : MonoBehaviour
{
    [SerializeField] Toggle[] parameters;

    void Start()
    {
        GetSelectedButton();
    }

    void GetSelectedButton()
    {
        for (int i = 0; i < parameters.Length; i++)
        {
            Toggle param = parameters[i];
            int buttonIndex = i;
            param.onValueChanged.AddListener((value) => ToggleValueChanged());
        }
    }

    void ToggleValueChanged()
    {
        for (int i = 0; i < parameters.Length; i++)
        {
            string message = parameters[i].isOn ? "включена" : "выключена";
            Debug.Log($"Ячейка {i}: галочка {message}");
        }
    }
}
