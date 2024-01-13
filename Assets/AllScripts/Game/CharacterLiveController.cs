using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLiveController : MonoBehaviour
{
    private int maxHp = 400;
    private int currHelth;
    private int painLevelValue = 1;
    private bool isPanic = false;

    internal protected Action onDead;
    internal protected static bool playerIsDead;

    [SerializeField] private Slider hpBar;
    [SerializeField] private Door door;
    [SerializeField] private GameObject liveBar;
    [SerializeField] private CharacterAnimation CharacterAnimation;
    [SerializeField] private GameOverPanel gameOverPanel;
    [SerializeField] private OpenDoorButton openDoorButton;
    [SerializeField] private Image liveBarColor;

    private void Start()
    {
        liveBarColor.color = SpecialColors.GetFirstColor();
        currHelth = maxHp;
        hpBar.maxValue = maxHp;
        hpBar.value = currHelth;
        door.onDoorClosed += StartHpController;
        openDoorButton.onSystemIsFixed += CalmDown;
        onDead += () => playerIsDead = true;
    }

    private void StartHpController()
    {
        painLevelValue = 2;
        isPanic = true;
        liveBar.SetActive(true);
        StartCoroutine(HpController());
    }

    private void CalmDown()
    {
        isPanic = false;
        liveBar.SetActive(false);
        ResetLive();
    }

    private IEnumerator HpController()
    {
        while (currHelth > 0 && isPanic)
        {
            yield return new WaitForSeconds(0.1f);
            currHelth -= painLevelValue;
            hpBar.value = currHelth; 
        }
        if (currHelth <= 0)
            onDead?.Invoke();
    }

    internal protected void ResetLive()
    {
        currHelth = maxHp;
        hpBar.maxValue = maxHp;
        hpBar.value = currHelth;
        liveBar.SetActive(false);
        playerIsDead = false;
        liveBarColor.color = SpecialColors.GetFirstColor();
    }
}
