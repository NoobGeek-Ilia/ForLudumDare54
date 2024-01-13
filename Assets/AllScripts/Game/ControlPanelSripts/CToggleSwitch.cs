using UnityEngine;
using UnityEngine.UI;

public class CToggleSwitch : MonoBehaviour
{
    internal protected static bool[] isRight;

    private Button[] buttons; // Используем private, так как мы будем заполнять его дочерними объектами

    [SerializeField] private Sprite left;
    [SerializeField] private Sprite right;

    internal protected void InitBoxButtons()
    {
        buttons = GetComponentsInChildren<Button>(); // Находим все кнопки в дочерних объектах
        isRight = new bool[buttons.Length];
        GetSelectedButton();
    }

    private void ChangeSprite(int index)
    {
        isRight[index] = !isRight[index];
        if (isRight[index])
            buttons[index].image.sprite = right;
        else
            buttons[index].image.sprite = left;
        SoundManager.instance.PlaySFX("ToggleButton");
    }

    private void GetSelectedButton()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            Button buttonComponent = buttons[i].GetComponent<Button>();
            int buttonIndex = i;
            buttonComponent.onClick.AddListener(() => ChangeSprite(buttonIndex));
        }
    }
}