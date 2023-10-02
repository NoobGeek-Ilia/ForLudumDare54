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
    int maxHp = 400;
    int currHelth;
    int painLevelValue = 1;

    internal protected Action onDead;
    bool isPanic = false;

    private void Start()
    {
        currHelth = maxHp;
        hpBar.maxValue = maxHp;
        hpBar.value = currHelth;
        door.onDoorClosed += StartHpController;
        openDoorButton.onSystemIsFixed += CalmDown;
        gameOverPanel.onReseted += () =>
        {
            ResetLive();
            liveBar.SetActive(false);
        };
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

    private void ResetLive()
    {
        currHelth = maxHp;
        hpBar.maxValue = maxHp;
        hpBar.value = currHelth;
    }
}
