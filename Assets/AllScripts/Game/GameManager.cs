using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Door door;
    [SerializeField] Animator animator;
    [SerializeField] CharacterLiveController characterLiveController;
    [SerializeField] GameObject gameoverPanel;
    private void Start()
    {
        door.onDoorClosed += () => animator.SetBool("isActive", true);
        door.onDoorOpened += () => animator.SetBool("isActive", false);
        characterLiveController.onDead += () => StartCoroutine(OpenGamePanel());
    }
    internal protected readonly static int[,] buttonNum = 
    { 
        { 2, 3, 4, 5, 6, 7, 8, 12 }, //onof
        { 1, 1, 2, 2, 3, 3, 4, 4 },  //toggle
        { 1, 2, 2, 3, 3, 4, 5, 6 },  //rot
        { 1, 1, 2, 2, 2, 4, 6, 6 },  //par
        { 1, 1, 1, 1, 2, 2, 2, 2 }   //slide
    };

    internal protected static int levelNum { get; private set; } = 3;
    internal protected static int currState;
    //OnOffSwitchBox;
    //ToggleSwitchBox;
    //RotatingSwitchBox;
    //ParameterBox;
    //Slider

    [SerializeField] Transform[] parentBox;

    [SerializeField] GameObject[] buttonPrefab;

    private void Awake()
    {
        SetButtons();
    }

    void SetButtons()
    {
        for (int i = 0; i < buttonNum.GetUpperBound(0) + 1; i++)
        {
            for (int j = 0; j < buttonNum[i, levelNum]; j++)
            {
                Instantiate(buttonPrefab[i], parentBox[i]);
            }
        }
    }
    IEnumerator OpenGamePanel()
    {
        yield return new WaitForSeconds(3f);
        gameoverPanel.SetActive(true);
    }
}
