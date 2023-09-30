using UnityEngine;
using UnityEngine.UI;

public class SToggleSwitch : MonoBehaviour
{
    private Button[] buttons;
    [SerializeField] Sprite left;
    [SerializeField] Sprite right;

    private bool[] isRight;

    private void Start()
    {
        buttons = GetComponentsInChildren<Button>();
        isRight = new bool[buttons.Length];
        SetStartValue();
    }
    internal void SetStartValue()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            float value = Random.value;
            isRight[i] = value > 0.5f;
            if (isRight[i])
                buttons[i].image.sprite = right;
            else
                buttons[i].image.sprite = left;
        }
    }
}