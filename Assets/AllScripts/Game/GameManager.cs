using System;
using System.Collections;
using System.Xml.Serialization;
using TMPro;
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
    [SerializeField] TextMeshProUGUI counterTxt;
    [SerializeField] GameObject PanicPic;
    [SerializeField] CFloorButtons floorButtons;
    private int counter;

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

    [SerializeField] Transform[] parentBox;

    [SerializeField] GameObject[] buttonPrefab;
    internal protected Action onBoxFull;

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
    void LevelUp()
    {
        counter++;
        for (int i = 1; i < buttonNum.GetLength(1); i++)
        {
            if (counter == i * 4)
                LevelNum++;
        }
        counterTxt.text = counter.ToString();
        Debug.Log($"numlevel: {LevelNum}");
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
                GameObject button = Instantiate(buttonPrefab[i], parentBox[i]);
                //button.transform.SetParent(parentBox[i], true);/
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
