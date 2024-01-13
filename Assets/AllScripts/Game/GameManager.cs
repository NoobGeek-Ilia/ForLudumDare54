using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameOverPanel gameOver;
    private int counter;

    internal protected Action onBoxFull;

    [SerializeField] private Door door;
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterLiveController characterLiveController;
    [SerializeField] private GameObject gameoverPanel;
    [SerializeField] private GameObject schemePanel;
    
    [SerializeField] private FillSchemePanel fillSchemePanel;
    [SerializeField] private OpenDoorButton openDoorButton;
    [SerializeField] private CharacterAnimation characterAnimation;
    [SerializeField] private TextMeshProUGUI counterTxt;
    [SerializeField] private GameObject PanicPic;
    [SerializeField] private CFloorButtons floorButtons;
    [SerializeField] private Transform[] parentBox;
    [SerializeField] private GameObject[] buttonPrefab;

    internal protected readonly static int[,] buttonNum = 
    { 
        { 2, 3, 4, 5, 6, 7, 8, 12 }, //onof
        { 1, 1, 2, 2, 3, 3, 3, 3 },  //toggle
        { 1, 2, 2, 3, 3, 4, 5, 6 },  //rot
        { 1, 1, 2, 2, 2, 4, 6, 6 },  //par
        { 1, 1, 1, 1, 2, 2, 3, 4 }   //slide
    };
    private static int levelNum = 0;

    internal protected static int LevelNum
    { 
        get
        {
            return levelNum;
        }
        set
        {
            if(value > buttonNum.GetLength(1) - 1)
                levelNum = buttonNum.GetLength(1) - 1;
            else
                levelNum = value;
        }
    }
    internal protected static int currState;

    private void Start()
    {
        SoundManager.instance.PlayMusic("BackRelax");
        characterAnimation.onButtonPressed += () =>
        {
            StartCoroutine(RemoveAndSetButtons());
        };
        door.onDoorClosed += () =>
        {
            animator.SetBool("isActive", true);
            
        };
        door.onDoorOpened += () => { animator.SetBool("isActive", false);   };
        characterLiveController.onDead += () => StartCoroutine(OpenGameOverPanel());
        gameOver = gameoverPanel.GetComponent<GameOverPanel>();
        gameOver.onReseted += () =>
        {
            ResetLevel();
            PanicPic.SetActive(false);
            SoundManager.instance.musicSource.Stop();
            SoundManager.instance.PlayMusic("BackRelax");
        };
        openDoorButton.onSystemIsFixed += () =>
        {
            LevelUp();
        };
    }
    private void LevelUp()
    {
        counter++;
        for (int i = 1; i < buttonNum.GetLength(1); i++)
        {
            if (counter == i * 2)
                LevelNum++;
        }
        counterTxt.text = counter.ToString();
    }
    private IEnumerator RemoveAndSetButtons()
    {
        RemoveAllChildren();
        fillSchemePanel.RemoveAllChildren();
        yield return new WaitForSeconds(0.1f);
        SetButtons();
    }
    internal protected void SetButtons()
    {
        for (int i = 0; i < buttonNum.GetUpperBound(0) + 1; i++)
        {
            for (int j = 0; j < buttonNum[i, levelNum]; j++)
            {
                GameObject button = Instantiate(buttonPrefab[i], parentBox[i]);
            }
        }
        onBoxFull?.Invoke();
    }
    private IEnumerator OpenGameOverPanel()
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
        floorButtons.ResertColor();
    }

    private void ResetLevel()
    {
        LevelNum = 0;
        counter = 0;
        counterTxt.text = counter.ToString();
        animator.SetBool("isActive", false);
        schemePanel.SetActive(false);
        characterLiveController.ResetLive();
    }
}
