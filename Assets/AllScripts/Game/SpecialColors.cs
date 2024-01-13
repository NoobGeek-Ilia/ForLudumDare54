using TMPro;
using UnityEngine;

public class SpecialColors : MonoBehaviour
{
    public static int ColorType
    {
        get
        {
            return tipe;
        }
        private set
        {
            if (tipe < 2)
                tipe = value;
            else
                tipe = 0;
        }
    }

    private static int tipe = 0;
    private string[] colorTypeName = { "N, T", "P, D", "U" };

    [SerializeField] private TextMeshProUGUI typeCountTxt;

    private void Start()
    {
        typeCountTxt.text = "N, T";
    }

    public void ChangeColor()
    {
        ColorType++;
        typeCountTxt.text = colorTypeName[ColorType];
    }

    internal protected static Color GetFirstColor()
    {
        switch (ColorType)
        {
            case 0:
                //default
                return Color.red;
            case 1:
                return Color.yellow;
            case 2:
                return Color.white;
            default:
                return Color.white;
        }
    }

    internal protected static Color GetSecondColor()
    {
        switch (ColorType)
        {
            case 0:
                //default
                return Color.green;
            case 1:
                return Color.blue;
            case 2:
                return Color.black;
            default:
                return Color.white;
        }
    }
}
