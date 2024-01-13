using UnityEngine;
using UnityEngine.UI;

public class COnOffSwitch : MonoBehaviour
{
    private Button[] buttons;

    internal protected static bool[] isActive;
    internal protected void InitBoxButtons()
    {
        buttons = GetComponentsInChildren<Button>();
        isActive = new bool[buttons.Length];
        foreach (Button button in buttons)
        {
            button.image.color = SpecialColors.GetFirstColor();
        }
        GetSelectedButton();
    }

    private void ChangeColor(int index)
    {
        isActive[index] = !isActive[index];
        if (isActive[index])
            buttons[index].image.color = SpecialColors.GetSecondColor();
        else
            buttons[index].image.color = SpecialColors.GetFirstColor();
        SoundManager.instance.PlaySFX("OnOffButton");
    }

    private void GetSelectedButton()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            Button buttonComponent = buttons[i].GetComponent<Button>();
            int buttonIndex = i;
            buttonComponent.onClick.AddListener(() => ChangeColor(buttonIndex));
        }
    }
}
