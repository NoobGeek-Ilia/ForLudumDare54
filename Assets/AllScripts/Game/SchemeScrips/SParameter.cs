using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SParameter : MonoBehaviour
{
    [SerializeField] Toggle[] parameters;

    void Start()
    {
        SetStartValue();
    }

    void SetStartValue()
    {
        for (int i = 0; i < parameters.Length; i++)
        {
            float value = Random.value;
            parameters[i].isOn = value > 0.5f;
        }
    }
}
