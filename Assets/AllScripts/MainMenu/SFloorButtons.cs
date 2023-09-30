using System;
using UnityEngine;
using UnityEngine.UI;
public class SFloorButtons : MonoBehaviour
{
    public Button[] buttons;
    private int currFloorIndex;
    private void Start()
    {
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
    }

    void OnButtonClick(Button currButton)
    {
        foreach (Button button in buttons)
        {
            button.image.color = Color.gray;
        }
        currButton.image.color = Color.green;
        currFloorIndex = Array.IndexOf(buttons, currButton);
        Debug.Log(currFloorIndex);
    }
}
