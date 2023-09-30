using UnityEngine;
using UnityEngine.UI;

public class SRotatingSwitch : MonoBehaviour
{
    [SerializeField] Button[] buttons;

    const int maxValue = 7;
    private int[] position;

    private void Start()
    {
        position = new int[buttons.Length];
        SetStartValue();
    }

    internal void SetStartValue()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int value = Random.Range(0, maxValue);
            position[i] = value;
            int rotationValue = 45 * value;
            Quaternion targetRotation = Quaternion.Euler(0, 0, rotationValue);
            buttons[i].transform.rotation = targetRotation;
        }
    }
}
