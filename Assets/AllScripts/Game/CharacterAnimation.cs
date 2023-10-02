using System;
using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CharacterAnimation : MonoBehaviour
{
    float moveSpeed = 0.8f;
    public Vector3[] targetPositions; // Массив целевых позиций
    Quaternion startRotation;
    [SerializeField] Animator animator;
    int animState;
    [SerializeField] Transform[] target;
    [SerializeField] Transform runPoint;
    [SerializeField] Door door;
    internal protected Action onButtonPressed;
    internal protected Action onSaved;
    [SerializeField] OpenDoorButton openDoorButton;
    [SerializeField] GameManager gameManager;

    [SerializeField] CharacterLiveController characterLiveController;
    [SerializeField] GameOverPanel gameOverPanel;

   

    private void Update()
    {
    }

    void Start()
    {
        startRotation = Quaternion.Euler(0, -69.761f, 0);
        StartCoroutine(PlayAnimation());
        openDoorButton.onSystemIsFixed += () => StartCoroutine(WalkToTarget(target[1].position));
        characterLiveController.onDead += () => { animator.SetBool("Run", false); animator.SetBool("Fell", true); };
        onSaved += ResetCharacter;
        gameOverPanel.onReseted += ResetCharacter;
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
                    animator.SetBool("Saved", false);
                    SoundManager.instance.PlaySFX("StuckEffect");

                    break;
                case 1:
                    //worry
                    animator.SetBool("PressButton", false);
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
        bool reachedTarget = false;

        while (!reachedTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, target) <= 0.01f)
            {
                reachedTarget = true;
            }

            yield return null;
        }

        animator.SetBool("Walk", false);

        if (target == this.target[1].position)
            onSaved?.Invoke();
    }


    public void OnAnimation() => animState++;

    private void ResetCharacter()
    {
        animState = 0;
        animator.SetBool("Worry", false);
        animator.SetBool("Fell", false);
        animator.SetBool("Run", false);
        animator.SetBool("Saved", true);
        transform.position = target[1].position;
        transform.rotation = startRotation;
        StartCoroutine(PlayAnimation());
    }
}
