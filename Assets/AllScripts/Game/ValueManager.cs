using UnityEngine.UI;

public class ValueManager
{
    private static bool[,] ToggleSwitchIsRight;


    internal protected static void SetValue(ButtonTipe tipe, bool[] value)
    {
        switch (tipe)
        {
            case ButtonTipe.COnOffSwitch:

                break;
            case ButtonTipe.CToggleSwitch:
                
                break;
            case ButtonTipe.CParemeter:
                break;
        }
    }

    internal protected static void SetValue(ButtonTipe tipe, int[] value)
    {

    }

    internal protected enum ButtonTipe
    {
        COnOffSwitch,
        CFloorButton,
        CToggleSwitch,
        CRotatingSwitch,
        CParemeter,
        SOnOffSwitch,
        SFloorButton,
        SToggleSwitch,
        SRotatingSwitch,
        SParemeter,
    }
}
