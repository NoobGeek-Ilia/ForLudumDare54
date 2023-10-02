using System;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    internal protected Action onReseted;
    public void CloseGameOverPanel()
    {
        gameOverPanel.SetActive(false);
        onReseted?.Invoke();
    }
}
