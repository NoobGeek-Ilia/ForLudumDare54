using System;
using UnityEngine;

public class FillSchemePanel : MonoBehaviour
{
    [SerializeField] Transform[] parentBox;
    [SerializeField] GameObject[] buttonPrefab;
    [SerializeField] GameOverPanel gameOverPanel;
    [SerializeField] Door door;
    internal protected Action onBoxFull;
    bool boxIsFull;

    private void Start()
    {
        door.onDoorClosed += () => boxIsFull = false;
    }
    private void SetButtons()
    {
        Debug.Log($"isFull: {boxIsFull}");
        if (!boxIsFull)
        {
            boxIsFull = true;
            for (int i = 0; i < GameManager.buttonNum.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < GameManager.buttonNum[i, GameManager.LevelNum]; j++)
                {
                    Instantiate(buttonPrefab[i], parentBox[i]);
                }
            }
            onBoxFull?.Invoke();
        }
    }

    internal protected void RemoveAllChildren()
    {
        foreach (Transform parent in parentBox)
        {
            foreach (Transform child in parent)
            {
                Destroy(child.gameObject);
            }
        }
        
    }
}
