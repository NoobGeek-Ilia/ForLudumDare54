using UnityEngine;
using UnityEngine.UI;

public class CRotatingSwitch : MonoBehaviour
{
    internal protected static int[] position;

    private Button[] buttons;
    private const float rotationStep = 45.0f;
    private float[] currentRotation;

    internal protected void InitBoxButtons()
    {
        buttons = GetComponentsInChildren<Button>(); // Находим все кнопки в дочерних объектах
        position = new int[buttons.Length];
        currentRotation = new float[buttons.Length];
        GetSelectedButton();
    }

    private void GetSelectedButton()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            Button buttonComponent = buttons[i].GetComponent<Button>();
            int buttonIndex = i;
            buttonComponent.onClick.AddListener(() => RotateSwitch(buttonIndex));
        }
    }

    private void RotateSwitch(int index)
    {
        currentRotation[index] -= rotationStep;
        Quaternion targetRotation = Quaternion.Euler(0, 0, currentRotation[index]);
        buttons[index].transform.rotation = targetRotation;
        position[index]++;
        if (position[index] > 7)
            position[index] = 0;
        SoundManager.instance.PlaySFX("RotateButton");
    }
}