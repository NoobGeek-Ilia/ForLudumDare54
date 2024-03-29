
using UnityEngine;

public class ValueManager
{
    internal protected bool EqualityCheck()
    {
        if (ParameterCheck() && RotatingSwitchCheck() && OnOffSwitchCheck()
            && SliderCheck() && FloorButtons() && ToggleSwitch())
            return true;
        return false;
    }
    internal protected bool ParameterCheck()
    {

        for (int i = 0; i < GameManager.buttonNum[3, GameManager.LevelNum]; i++)
        {
            if (SParameter.isActive[i] != CParameter.isActive[i])
                return false;
        }
        return true;
    }
    private bool RotatingSwitchCheck()
    {
        for (int i = 0; i < GameManager.buttonNum[2, GameManager.LevelNum]; i++)
        {
            if (SRotatingSwitch.position[i] != CRotatingSwitch.position[i])
                return false;
        }
        return true;
    }

    private bool OnOffSwitchCheck()
    {
        for (int i = 0; i < GameManager.buttonNum[0, GameManager.LevelNum]; i++)
        {
            if (SOnOffSwitch.isActive[i] != COnOffSwitch.isActive[i])
                return false;
        }
        return true;
    }
    
    private bool SliderCheck()
    {
        for (int i = 0; i < GameManager.buttonNum[4, GameManager.LevelNum]; i++)
        {
            if (SSlider.sliderValues[i] != CSlider.sliderValues[i])
            {
                return false;
            }
        }
        return true;
    }

    private bool FloorButtons()
    {
        if (SFloorButtons.currFloorIndex != CFloorButtons.currFloorIndex)
            return false;
        return true;
    }

    private bool ToggleSwitch()
    {
        for (int i = 0; i < GameManager.buttonNum[1, GameManager.LevelNum]; i++)
        {
            if (SToggleSwitch.isRight[i] != CToggleSwitch.isRight[i])
            {
                return false;
            }
        }
        return true;
    }
}
