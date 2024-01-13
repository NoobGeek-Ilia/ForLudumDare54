using System;
using UnityEngine;

public class OpenDoorButton : MonoBehaviour
{
    public bool Door;

    internal protected static bool doorIsOpen;
    internal protected Action onSystemIsFixed;

    private ValueManager valueManager = new ValueManager();

    [SerializeField] private GameObject schemePanel;
    [SerializeField] private Door door;
    [SerializeField] private GameObject PanicPic;

    private void Start()
    {
        door.onDoorClosed += () => doorIsOpen = false;
    }
    public void SendMessageToTheDoor()
    {
        if (valueManager.EqualityCheck() && !CharacterLiveController.playerIsDead && !doorIsOpen)
        {
            onSystemIsFixed?.Invoke();
            Debug.Log("OK");
            doorIsOpen = true;
            schemePanel.SetActive(false);
            SoundManager.instance.musicSource.Stop();
            PanicPic.SetActive(false);
            SoundManager.instance.PlayMusic("BackRelax");
        }
        else
        {
            Debug.Log("ERROR");
            SoundManager.instance.PlaySFX("ErrorEffect");
        }
    }
}
