using UnityEngine;
using UnityEngine.UI;

public class SOnOffSwitch : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    private bool[] isActive;

    private void Start()
    {
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
}
