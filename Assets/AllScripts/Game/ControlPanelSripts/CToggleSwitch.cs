using UnityEngine;
using UnityEngine.UI;

public class CToggleSwitch : MonoBehaviour
{
    private Button[] buttons; // Используем private, так как мы будем заполнять его дочерними объектами
    [SerializeField] Sprite left;
    [SerializeField] Sprite right;

    internal protected static bool[] isRight;

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

        for (int i = 0; i < buttons.Length; i++)
        {
            Debug.Log($"{i}: {isRight[i]}");
        }
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
