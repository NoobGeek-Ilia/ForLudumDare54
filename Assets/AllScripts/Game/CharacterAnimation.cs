using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CharacterAnimation : MonoBehaviour
{
    float moveSpeed = 0.8f;
    public Vector3[] targetPositions; // Массив целевых позиций
    [SerializeField] Animator animator;
    int animState;
    [SerializeField] Transform[] elevator;
    [SerializeField] Transform runPoint;

    // Новые переменные для бега по кругу
    public float rotationSpeed = 0.1f;
    private float angle = 0f;


    void Start()
    {
        StartCoroutine(PlayAnimation());
    }

    IEnumerator PlayAnimation()
    {
        while (animState != 3)
        {
            switch (animState)
            {
                case 0:
                    //goToElevator + pressButton
                    yield return StartCoroutine(WalkToTarget(elevator[0].position));    
                    animator.SetBool("PressButton", true);
                    break;
                case 1:
                    //worry
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
