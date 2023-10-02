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

    private void Start()
    {
        door.onDoorClosed += () => doorIsOpen = false;
    }
    public void SendMessageToTheDoor()
    {
        if (valueManager.EqualityCheck())
        {
            onSystemIsFixed?.Invoke();
            Debug.Log("OK");
            doorIsOpen = true;
            schemePanel.SetActive(false);
            GameManager.levelNum++;
        }
        else
            Debug.Log("ERROR");

        Debug.Log($"doorIsOpen: {doorIsOpen}");
    }
}
