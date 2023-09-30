using UnityEngine;
using UnityEngine.UI;

public class COnOffSwitch : MonoBehaviour
{
    Button[] buttons;
    private bool[] isActive;

    private void Start()
    {
        buttons = GetComponentsInChildren<Button>();
        isActive = new bool[buttons.Length];
        foreach (Button button in buttons)
        {
            button.image.color = Color.red;
        }
        GetSelectedButton();
    }

    public void ChangeColor(int index)
    {
        isActive[index] = !isActive[index];
        if (isActive[index])
            buttons[index].image.color = Color.green;
        else
            buttons[index].image.color = Color.red;

        
        for (int i = 0; i < buttons.Length; i++)
        {
            Debug.Log($"{i}: {isActive[i]}");
        }
    }

    void GetSelectedButton()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            Button buttonComponent = buttons[i].GetComponent<Button>();
            int buttonIndex = i;
            buttonComponent.onClick.AddListener(() => ChangeColor(buttonIndex));
        }
    }

    internal protected void SetButtValue(bool[] isActive)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            this.isActive[i] = isActive[i];
        }
    }
}
