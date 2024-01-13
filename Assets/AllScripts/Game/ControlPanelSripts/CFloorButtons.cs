using System;
using UnityEngine;
using UnityEngine.UI;

public class CFloorButtons : MonoBehaviour
{
    public Button[] buttons;

    internal protected static int currFloorIndex;

    private void Start()
    {
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
    }

    private void OnButtonClick(Button currButton)
    {
        ResertColor();
        currButton.image.color = SpecialColors.GetSecondColor();
        currFloorIndex = Array.IndexOf(buttons, currButton);
        SoundManager.instance.PlaySFX("FloorButton");
    }

    internal protected void ResertColor()
    {
        foreach (Button button in buttons)
        {
            button.image.color = Color.gray;
        }
    }
}