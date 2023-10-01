using System;
using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CharacterAnimation : MonoBehaviour
{
    float moveSpeed = 0.8f;
    public Vector3[] targetPositions; // Массив целевых позиций
    [SerializeField] Animator animator;
    int animState;
    [SerializeField] Transform[] target;
    [SerializeField] Transform runPoint;
    [SerializeField] Door door;
    internal protected Action onButtonPressed;
    [SerializeField] CharacterLiveController characterLiveController;
    public float rotationSpeed = 0.1f;
    private float angle = 0f;


    void Start()
    {
        StartCoroutine(PlayAnimation());
        door.onDoorOpened += () =>
        {
            Debug.Log("goAWAAAAAAY");
            animator.SetBool("Run", false);
            StartCoroutine(WalkToTarget(target[1].position));
        };
        characterLiveController.onDead += () => { animator.SetBool("Run", false); animator.SetBool("Fell", true); };
    }

    IEnumerator PlayAnimation()
    {
        while (animState != 3)
        {
            switch (animState)
            {
                case 0:
                    //goToElevator + pressButton
                    yield return StartCoroutine(WalkToTarget(target[0].position));    
                    animator.SetBool("PressButton", true);
                    
                    break;
                case 1:
                    //worry
                    onButtonPressed?.Invoke();
                    animator.SetBool("Worry", true);
                    yield return new WaitForSeconds(2f);
                    animator.SetBool("Worry", false);
                    animState++;
                    break;
                case 2:
                //Run
                    animator.SetBool("Run", true);
                    StartCoroutine(WalkToTarget(runPoint.position));
                    animState++;
                    break;
                case 3:

                    break;
            }
        }
    }

    IEnumerator WalkToTarget(Vector3 target)
    {
        animator.SetBool("Walk", true);
        while (Vector3.Distance(transform.position, target) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
            yield return null;
        }
        animator.SetBool("Walk", false);
    }

    public void OnAnimation()
    {
        animState++;
        animator.SetBool("PressButton", false);
    }
}
