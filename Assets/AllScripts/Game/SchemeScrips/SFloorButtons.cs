using UnityEngine;
using UnityEngine.UI;
public class SFloorButtons : MonoBehaviour
{
    public Button[] buttons;
    internal protected static int currFloorIndex;

    private void Start()
    {
        SetStartValue();
    }

    internal protected void SetStartValue()
    {
        foreach (Button button in buttons)
        {
            button.image.color = Color.gray;
        }
        for (int i = 0; i < buttons.Length; i++)
        {
            int value = Random.Range(0, buttons.Length);
            currFloorIndex = value;
        }
        buttons[currFloorIndex].image.color = Color.green;
    }
}
