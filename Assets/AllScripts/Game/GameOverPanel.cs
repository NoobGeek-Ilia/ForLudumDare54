using System;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    internal protected Action onReseted;
    public void CloseGameOverPanel()
    {
        onReseted?.Invoke();
        gameOverPanel.SetActive(false);
       
    }
}
