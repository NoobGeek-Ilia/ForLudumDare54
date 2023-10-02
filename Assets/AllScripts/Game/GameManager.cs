using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Door door;
    [SerializeField] Animator animator;
    [SerializeField] CharacterLiveController characterLiveController;
    [SerializeField] GameObject gameoverPanel;
    [SerializeField] GameObject schemePanel;
    GameOverPanel gameOver;
    [SerializeField] FillSchemePanel fillSchemePanel;
    [SerializeField] OpenDoorButton openDoorButton;
    [SerializeField] CharacterAnimation characterAnimation;

    internal protected readonly static int[,] buttonNum = 
    { 
        { 2, 3, 4, 5, 6, 7, 8, 12 }, //onof
        { 1, 1, 2, 2, 3, 3, 4, 4 },  //toggle
        { 1, 2, 2, 3, 3, 4, 5, 6 },  //rot
        { 1, 1, 2, 2, 2, 4, 6, 6 },  //par
        { 1, 1, 1, 1, 2, 2, 2, 2 }   //slide
    };

    internal protected static int levelNum { get; set; } = 0;
    internal protected static int currState;

    [SerializeField] Transform[] parentBox;

    [SerializeField] GameObject[] buttonPrefab;
    internal protected Action onBoxFull;

    private void Start()
    {
        characterAnimation.onButtonPressed += () =>
        {
            StartCoroutine(RemoveAndSetButtons());
        };
        door.onDoorClosed += () =>
        {
            animator.SetBool("isActive", true);
        };
        door.onDoorOpened += () => { animator.SetBool("isActive", false);  };
        characterLiveController.onDead += () => StartCoroutine(OpenGameOverPanel());
        gameOver = gameoverPanel.GetComponent<GameOverPanel>();
        gameOver.onReseted += ResetLevel;
    }
    IEnumerator RemoveAndSetButtons()
    {
        RemoveAllChildren();
        fillSchemePanel.RemoveAllChildren();

        // Подождать некоторое время перед инициализацией новых элементов
        yield return new WaitForSeconds(0.1f);

        SetButtons();
    }
    internal protected void SetButtons()
    {
        for (int i = 0; i < buttonNum.GetUpperBound(0) + 1; i++)
        {
            for (int j = 0; j < buttonNum[i, levelNum]; j++)
            {
                Instantiate(buttonPrefab[i], parentBox[i]);
            }
        }
        onBoxFull?.Invoke();
    }
    IEnumerator OpenGameOverPanel()
    {
        yield return new WaitForSeconds(3f);
        gameoverPanel.SetActive(true);
    }

    private void RemoveAllChildren()
    {
        foreach (Transform parent in parentBox)
        {
            foreach (Transform child in parent)
            {
                Destroy(child.gameObject);
            }
        }
    }

    private void ResetLevel()
    {
        levelNum = 0;
        animator.SetBool("isActive", false);
        schemePanel.SetActive(false);
    }
}
