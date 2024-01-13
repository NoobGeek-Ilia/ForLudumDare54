using UnityEngine;

public class ShemeButton : MonoBehaviour
{
    [SerializeField] private GameObject shchemePanel;
    public void OpenSchemePanel()
    {
        shchemePanel.SetActive(true);
        SoundManager.instance.PlaySFX("OpenSchemeButton");
    }
}