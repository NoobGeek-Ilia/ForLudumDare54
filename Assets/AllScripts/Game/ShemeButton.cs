using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShemeButton : MonoBehaviour
{
    [SerializeField] GameObject shchemePanel;
    public void OpenSchemePanel()
    {
        shchemePanel.SetActive(true);
        SoundManager.instance.PlaySFX("OpenSchemeButton");
    }
}
