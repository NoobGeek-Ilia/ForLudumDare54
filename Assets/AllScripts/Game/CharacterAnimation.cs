using System;
using System.Collections;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    public Vector3[] targetPositions;

    private float moveSpeed = 0.8f;
    private Quaternion startRotation;
    private int animState;

    internal protected Action onButtonPressed;
    internal protected Action onSaved;

    [SerializeField] private Animator animator;
    [SerializeField] private Transform[] target;
    [SerializeField] private Transform runPoint;
    [SerializeField] private Door door;
    [SerializeField] private OpenDoorButton openDoorButton;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private CharacterLiveController characterLiveController;
    [SerializeField] private GameOverPanel gameOverPanel;
    [SerializeField] private GameObject PanicPic;

    private void Start()
    {
        startRotation = Quaternion.Euler(0, -69.761f, 0);
        StartCoroutine(PlayAnimation());
        openDoorButton.onSystemIsFixed += () => StartCoroutine(WalkToTarget(target[1].position));
        characterLiveController.onDead += () => { animator.SetBool("Run", false); animator.SetBool("Fell", true); };
        onSaved += ResetCharacter;
        gameOverPanel.onReseted += ResetCharacter;
    }

    private IEnumerator PlayAnimation()
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
                    SoundManager.instance.musicSource.Stop();
                    SoundManager.instance.PlayMusic("PanicBack");
                    SoundManager.instance.PlaySFX("GirlPanic");
                    PanicPic.SetActive(true);
                    break;
                case 3:

                    break;
            }
        }
    }


    private IEnumerator WalkToTarget(Vector3 target)
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
