using UnityEngine;
using UnityEngine.UI;

public class SRotatingSwitch : MonoBehaviour
{  
    internal protected static int[] position;

    private const int maxValue = 7;
    private Button[] buttons;

    internal protected void InitBoxButtons()
    {
        buttons = GetComponentsInChildren<Button>();
        position = new int[buttons.Length];
        SetStartValue();
    }

    private void SetStartValue()
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