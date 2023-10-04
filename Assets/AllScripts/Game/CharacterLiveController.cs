using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLiveController : MonoBehaviour
{
    [SerializeField] Slider hpBar;
    [SerializeField] Door door;
    [SerializeField] GameObject liveBar;
    [SerializeField] CharacterAnimation CharacterAnimation;
    [SerializeField] GameOverPanel gameOverPanel;
    [SerializeField] OpenDoorButton openDoorButton;
    [SerializeField] Image liveBarColor;

    int maxHp = 400;
    int currHelth;
    int painLevelValue = 1;

    internal protected Action onDead;
    internal protected static bool playerIsDead;
    bool isPanic = false;

    private void Start()
    {
        liveBarColor.color = SpecialColors.GetSecondColor();
        currHelth = maxHp;
        hpBar.maxValue = maxHp;
        hpBar.value = currHelth;
        door.onDoorClosed += StartHpController;
        openDoorButton.onSystemIsFixed += CalmDown;
        gameOverPanel.onReseted += () =>
        {
            Debug.Log("reseted");

            
        };
        onDead += () => playerIsDead = true;
    }

    void StartHpController()
    {
        painLevelValue = 2;
        isPanic = true;
        liveBar.SetActive(true);
        StartCoroutine(HpController());

    }

    void CalmDown()
    {
        isPanic = false;
        liveBar.SetActive(false);
        ResetLive();
    }

    IEnumerator HpController()
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
        liveBarColor.color = SpecialColors.GetSecondColor();
    }
}
