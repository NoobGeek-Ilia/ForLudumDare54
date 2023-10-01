using System;
using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    float distanceToMove = 3.0f;
    [SerializeField] Transform rightDoor;
    [SerializeField] Transform leftDoor;
    internal protected Action onDoorClosed;
    internal protected Action onDoorOpened;


    void OpenTheDoor(bool open)
    {
        if (open)
        {
            rightDoor.Translate(Vector3.right * distanceToMove);
            leftDoor.Translate(Vector3.right * (-distanceToMove));
        }
        else
        {
            rightDoor.Translate(Vector3.right * -distanceToMove);
            leftDoor.Translate(Vector3.right * distanceToMove);
        }
    }
}
