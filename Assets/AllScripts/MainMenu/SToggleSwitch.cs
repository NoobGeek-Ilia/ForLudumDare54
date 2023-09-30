using UnityEngine;
using UnityEngine.UI;

public class SToggleSwitch : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    [SerializeField] Sprite left;
    [SerializeField] Sprite right;

    private bool[] isRight;

    private void Start()
    {
        isRight = new bool[buttons.Length];
        GetSelectedButton();
    }
    public void ChangeSprite(int index)
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
    void GetSelectedButton()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            Button buttonComponent = buttons[i].GetComponent<Button>();
            int buttonIndex = i;
            buttonComponent.onClick.AddListener(() => ChangeSprite(buttonIndex));
        }

    }
}