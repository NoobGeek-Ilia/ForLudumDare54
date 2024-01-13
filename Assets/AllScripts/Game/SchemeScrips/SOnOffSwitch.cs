using UnityEngine;
using UnityEngine.UI;

public class SOnOffSwitch : MonoBehaviour
{
    internal protected static bool[] isActive;

    private Button[] buttons;

    internal protected void InitBoxButtons()
    {
        buttons = GetComponentsInChildren<Button>();
        isActive = new bool[buttons.Length];
        SetStartValue();
    }

    private void SetStartValue()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            float value = Random.value;
            isActive[i] = value > 0.5f;
            if (isActive[i])
                buttons[i].image.color = SpecialColors.GetSecondColor();
            else
                buttons[i].image.color = SpecialColors.GetFirstColor();
        }
    }
}