using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SFloorButtons : MonoBehaviour
{
    public Button[] buttons;
    internal protected static int currFloorIndex;

    private void Start()
    {
        SetStartValue();
    }
    internal protected void InitBoxButtons()
    {
        SetStartValue();
    }

    internal protected void SetStartValue()
    {
        foreach (Button button in buttons)
        {
            button.image.color = Color.gray;
        }
        int value = Random.Range(0, buttons.Length);
        currFloorIndex = value;
        buttons[currFloorIndex].image.color = SpecialColors.GetSecondColor();
    }
}
