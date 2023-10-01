using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLiveController : MonoBehaviour
{
    [SerializeField] Slider hpBar;
    [SerializeField] Door door;
    [SerializeField] GameObject liveBar;
    int maxHp = 200;
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
        door.onDoorOpened += SaveCharacter;
    }

    void StartHpController()
    {
        painLevelValue = GameManager.levelNum / 3;
        isPanic = true;
        liveBar.SetActive(true);
        StartCoroutine(HpController());
    }

    void SaveCharacter()
    {
        isPanic = false;
        liveBar.SetActive(false);
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
}
