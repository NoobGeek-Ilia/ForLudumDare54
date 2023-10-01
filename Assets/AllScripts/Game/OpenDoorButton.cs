using System;
using UnityEngine;

public class OpenDoorButton : MonoBehaviour
{
    
    ValueManager valueManager = new ValueManager();
    public bool Door;
    internal protected static bool doorIsOpen;
    internal protected Action onSystemIsFixed;
    [SerializeField] GameObject schemePanel;

    public void SendMessageToTheDoor()
    {
        if (valueManager.EqualityCheck() && !doorIsOpen)
        {
            onSystemIsFixed?.Invoke();
            Debug.Log("OK");
            doorIsOpen = true;
            schemePanel.SetActive(false);
        }
        else
            Debug.Log("ERROR");
    }
}
