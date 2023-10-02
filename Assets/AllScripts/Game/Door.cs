using System;
using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    float distanceToMove = 0.5f;
    float openTime = 1f; // ¬рем€ открыти€/закрыти€ (в секундах)
    [SerializeField] Transform rightDoor;
    [SerializeField] Transform leftDoor;
    internal protected Action onDoorClosed;
    internal protected Action onDoorOpened;
    [SerializeField] CharacterAnimation characterAnimation;
    [SerializeField] OpenDoorButton openDoor;
    [SerializeField] GameOverPanel gameOverPanel;

    private void Start()
    {
        characterAnimation.onButtonPressed += () => StartCoroutine(OpenCoroutine(true));
        openDoor.onSystemIsFixed += () => StartCoroutine(OpenCoroutine(false));
        gameOverPanel.onReseted += () => StartCoroutine(OpenCoroutine(false));
    }

    private IEnumerator OpenCoroutine(bool open)
    {//все перепутано
        Debug.Log("corunine");
        SoundManager.instance.PlaySFX("OpenDoorEffect");
        Vector3 startPosRight = rightDoor.position;
        Vector3 startPosLeft = leftDoor.position;
        Vector3 endPosRight, endPosLeft;

        if (open)
        {
            endPosRight = startPosRight + rightDoor.right * distanceToMove;
            endPosLeft = startPosLeft + leftDoor.right * -distanceToMove;
        }
        else
        {
            endPosRight = startPosRight + rightDoor.right * -distanceToMove;
            endPosLeft = startPosLeft + leftDoor.right * distanceToMove;
        }

        float startTime = Time.time;
        while (Time.time < startTime + openTime)
        {
            float t = (Time.time - startTime) / openTime;
            rightDoor.position = Vector3.Lerp(startPosRight, endPosRight, t);
            leftDoor.position = Vector3.Lerp(startPosLeft, endPosLeft, t);
            yield return null;
        }

        rightDoor.position = endPosRight;
        leftDoor.position = endPosLeft;

        if (open)
        {
            onDoorClosed?.Invoke();
        }
        else
        {
            onDoorOpened?.Invoke();
            
        }
        
    }
}
