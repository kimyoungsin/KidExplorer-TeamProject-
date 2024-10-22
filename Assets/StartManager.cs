using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    public GameObject uiPanel; // 시작 시 표시할 UI 패널
    public Button button1; // 버튼 1
    public Button button2; // 버튼 2
    public Button button3; // 버튼 3
    public Button button4; // 버튼 4

    public PlayerMovement PlayerMovement;

    public GameObject npc;

    private void Start()

    {
        PlayerMovement = FindObjectOfType<PlayerMovement>();
        // 시작 시 UI 패널 활성화
        uiPanel.SetActive(true);
        PlayerMovement.StopMove();
        PlayerMovement.UItext.isStopMeter = true;
        // 버튼 1 클릭 시 호출될 함수 설정
        button1.onClick.AddListener(Button1Click);

        // 버튼 2 클릭 시 호출될 함수 설정
        button2.onClick.AddListener(Button2Click);

        // 버튼 3 클릭 시 호출될 함수 설정
        button3.onClick.AddListener(Button3Click);

        // 버튼 4 클릭 시 호출될 함수 설정
        button4.onClick.AddListener(Button4Click);

    }

    // 버튼 1 클릭 시 호출되는 함수
    private void Button1Click()
    {
        npc.SetActive(false);
        PlayerMovement.UItext.BulidImprovement += 20;
        End();
    }

    // 버튼 2 클릭 시 호출되는 함수
    private void Button2Click()
    {
        PlayerMovement.UItext.Hunger -= 20f;
        PlayerMovement.UItext.TimeCount += 25f;

        End();
    }

    // 버튼 3 클릭 시 호출되는 함수
    private void Button3Click()
    {
        PlayerMovement.HungerConsumptionRate *= 1.25f;
        PlayerMovement.SprintScale *= 1.25f;

        End();
    }

    // 버튼 4 클릭 시 호출되는 함수
    private void Button4Click()
    {

        End();
    }

    private void End()
    {
        PlayerMovement.StopMove();
        PlayerMovement.UItext.isStopMeter = false;
        uiPanel.SetActive(false);

    }
}
