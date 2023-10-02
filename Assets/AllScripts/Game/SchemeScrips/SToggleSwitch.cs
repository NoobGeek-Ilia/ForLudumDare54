using UnityEngine;
using UnityEngine.UI;

public class SToggleSwitch : MonoBehaviour
{
    private Button[] buttons;
    [SerializeField] Sprite left;
    [SerializeField] Sprite right;

    internal protected static bool[] isRight;

    internal protected void InitBoxButtons()
    {
        buttons = GetComponentsInChildren<Button>();
        isRight = new bool[buttons.Length];
        SetStartValue();
    }

    private void SetStartValue()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            float value = Random.value;
            isRight[i] = value > 0.5f;
            if (isRight[i])
                buttons[i].image.sprite = right;
            else
                buttons[i].image.sprite = left;
            Debug.Log($"Toggle {isRight[i]}");
        }
    }
}