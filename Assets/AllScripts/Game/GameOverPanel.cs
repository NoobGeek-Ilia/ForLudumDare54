using System;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    internal protected Action onReseted;

    [SerializeField] private GameObject gameOverPanel;
    
    public void CloseGameOverPanel()
    {
        onReseted?.Invoke();
        gameOverPanel.SetActive(false);
    }
}
