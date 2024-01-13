using System;
using System.Collections;
using UnityEngine;

public class Door : MonoBehaviour
{
    private float distanceToMove = 0.5f;
    private float openTime = 1f;

    internal protected Action onDoorClosed;
    internal protected Action onDoorOpened;

    [SerializeField] private Transform rightDoor;
    [SerializeField] private Transform leftDoor;
    [SerializeField] private CharacterAnimation characterAnimation;
    [SerializeField] private OpenDoorButton openDoor;
    [SerializeField] private GameOverPanel gameOverPanel;

    private void Start()
    {
        characterAnimation.onButtonPressed += () => StartCoroutine(OpenCoroutine(true));
        openDoor.onSystemIsFixed += () =>
        {
            StartCoroutine(OpenCoroutine(false));
            SoundManager.instance.PlaySFX("OpenDoorEffect");
        };
        gameOverPanel.onReseted += () =>
        {
            StartCoroutine(OpenCoroutine(false));
            SoundManager.instance.PlaySFX("OpenDoorEffect");
        };
    }

    private IEnumerator OpenCoroutine(bool open)
    {
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
