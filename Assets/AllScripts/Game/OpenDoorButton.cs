using System;
using UnityEngine;

public class OpenDoorButton : MonoBehaviour
{
    
    ValueManager valueManager = new ValueManager();
    public bool Door;
    internal protected static bool doorIsOpen;
    internal protected Action onSystemIsFixed;
    [SerializeField] GameObject schemePanel;
    [SerializeField] Door door;
    [SerializeField] GameObject PanicPic;

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

        Debug.Log($"doorIsOpen: {doorIsOpen}");
    }
}
