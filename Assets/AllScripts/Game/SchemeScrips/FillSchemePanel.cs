using System;
using UnityEngine;

public class FillSchemePanel : MonoBehaviour
{
    internal protected Action onBoxFull;

    private bool boxIsFull;

    [SerializeField] private Transform[] parentBox;
    [SerializeField] private GameObject[] buttonPrefab;
    [SerializeField] private GameOverPanel gameOverPanel;
    [SerializeField] private Door door;
   
    private void Start()
    {
        door.onDoorClosed += () => boxIsFull = false;
    }

    public void SetButtons()
    {
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