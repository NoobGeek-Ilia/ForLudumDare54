using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    public void CloseGameOverPanel()
    {
        gameOverPanel.SetActive(false);
    }
}
