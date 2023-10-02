using System;
using UnityEngine;

public class FillSchemePanel : MonoBehaviour
{
    [SerializeField] Transform[] parentBox;
    [SerializeField] GameObject[] buttonPrefab;
    [SerializeField] GameOverPanel gameOverPanel;
    internal protected Action onBoxFull;
    bool boxIsFull;

    private void SetButtons()
    {
        if (!boxIsFull)
        {
            foreach (Transform parent in parentBox)
            {
                int childCount = parent.childCount;
                Debug.Log("У родителя " + parent.name + " " + childCount + " дочерних объектов.");
            }
            for (int i = 0; i < GameManager.buttonNum.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < GameManager.buttonNum[i, GameManager.levelNum]; j++)
                {
                    Instantiate(buttonPrefab[i], parentBox[i]);
                }
            }
            onBoxFull?.Invoke();
            boxIsFull = true;
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
        boxIsFull = false;
    }
}
