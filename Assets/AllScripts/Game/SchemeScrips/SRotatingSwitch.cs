using UnityEngine;
using UnityEngine.UI;

public class SRotatingSwitch : MonoBehaviour
{
    private Button[] buttons;

    const int maxValue = 7;
    internal protected static int[] position;

    private void Start()
    {
        buttons = GetComponentsInChildren<Button>();
        position = new int[buttons.Length];
        SetStartValue();

        // ������� �������� ��������� ������� position
        for (int i = 0; i < position.Length; i++)
        {
            Debug.Log("position[" + i + "] = " + position[i]);
        }
    }

    internal void SetStartValue()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int value = Random.Range(0, maxValue);
            position[i] = value;
            int rotationValue = -45 * value;
            Quaternion targetRotation = Quaternion.Euler(0, 0, rotationValue);
            buttons[i].transform.rotation = targetRotation;
        }
    }
}
