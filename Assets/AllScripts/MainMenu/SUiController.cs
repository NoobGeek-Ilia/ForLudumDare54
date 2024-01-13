using UnityEngine;
using UnityEngine.SceneManagement;
public class SUiController : MonoBehaviour
{
    private const string GameSceneName = "Game";
    public void PlayBut()
    {
        SceneManager.LoadScene(GameSceneName);
    }
}
