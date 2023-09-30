using UnityEngine;

public class GameManager : MonoBehaviour
{
    readonly int[,] buttonNum = 
    { 
        { 5, 3, 4, 5, 6, 7, 8, 12 }, //onof
        { 3, 1, 2, 2, 3, 3, 4, 4 },  //toggle
        { 3, 2, 2, 3, 3, 4, 5, 6 },  //rot
        { 5, 1, 2, 2, 2, 4, 6, 6 },  //par
        { 2, 1, 1, 1, 2, 2, 2, 2 }   //slide
    }; 
    internal protected int levelNum;
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
}
