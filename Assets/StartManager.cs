using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    public GameObject uiPanel; // ���� �� ǥ���� UI �г�
    public Button button1; // ��ư 1
    public Button button2; // ��ư 2
    public Button button3; // ��ư 3
    public Button button4; // ��ư 4

    public PlayerMovement PlayerMovement;

    public GameObject npc;

    private void Start()

    {
        PlayerMovement = FindObjectOfType<PlayerMovement>();
        // ���� �� UI �г� Ȱ��ȭ
        uiPanel.SetActive(true);
        PlayerMovement.StopMove();
        PlayerMovement.UItext.isStopMeter = true;
        // ��ư 1 Ŭ�� �� ȣ��� �Լ� ����
        button1.onClick.AddListener(Button1Click);

        // ��ư 2 Ŭ�� �� ȣ��� �Լ� ����
        button2.onClick.AddListener(Button2Click);

        // ��ư 3 Ŭ�� �� ȣ��� �Լ� ����
        button3.onClick.AddListener(Button3Click);

        // ��ư 4 Ŭ�� �� ȣ��� �Լ� ����
        button4.onClick.AddListener(Button4Click);

    }

    // ��ư 1 Ŭ�� �� ȣ��Ǵ� �Լ�
    private void Button1Click()
    {
        npc.SetActive(false);
        PlayerMovement.UItext.BulidImprovement += 20;
        End();
    }

    // ��ư 2 Ŭ�� �� ȣ��Ǵ� �Լ�
    private void Button2Click()
    {
        PlayerMovement.UItext.Hunger -= 20f;
        PlayerMovement.UItext.TimeCount += 25f;

        End();
    }

    // ��ư 3 Ŭ�� �� ȣ��Ǵ� �Լ�
    private void Button3Click()
    {
        PlayerMovement.HungerConsumptionRate *= 1.25f;
        PlayerMovement.SprintScale *= 1.25f;

        End();
    }

    // ��ư 4 Ŭ�� �� ȣ��Ǵ� �Լ�
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
