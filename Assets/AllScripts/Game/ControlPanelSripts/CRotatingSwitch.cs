using UnityEngine;
using UnityEngine.UI;

public class CRotatingSwitch : MonoBehaviour
{
    private Button[] buttons;

    const float rotationStep = 45.0f;
    private int[] position;
    private float[] currentRotation;

    private void Start()
    {
        buttons = GetComponentsInChildren<Button>(); // ������� ��� ������ � �������� ��������
        position = new int[buttons.Length];
        currentRotation = new float[buttons.Length];
        GetSelectedButton();
    }

    void GetSelectedButton()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            Button buttonComponent = buttons[i].GetComponent<Button>();
            int buttonIndex = i;
            buttonComponent.onClick.AddListener(() => RotateSwitch(buttonIndex));
        }
    }

    public void RotateSwitch(int index)
    {
        currentRotation[index] -= rotationStep;
        Quaternion targetRotation = Quaternion.Euler(0, 0, currentRotation[index]);
        buttons[index].transform.rotation = targetRotation;
        position[index]++;
        if (position[index] > 7)
            position[index] = 0;
        for (int i = 0; i < buttons.Length; i++)
        {
            Debug.Log($"{i}: {position[i]}");
        }
    }
}
