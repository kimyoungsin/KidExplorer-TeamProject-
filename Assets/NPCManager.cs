using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCManager : MonoBehaviour
{
    public GameObject uiWindow; // 열리게 될 UI 창
    public GameObject buttonContainer; // 버튼들을 담을 컨테이너 오브젝트
    public Button[] buttons; // 버튼 배열

    public Inventory Inventory;

    public List<Items> Items;
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiWindow.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiWindow.SetActive(false);
        }
    }

    private void Start()
    {
        AddButtonsFunctions();
        Inventory = FindObjectOfType<Inventory>();
    }
    public void AddButtonsFunctions()
    {
        buttons = buttonContainer.GetComponentsInChildren<Button>();

        if (buttons.Length == 4)
        {
            buttons[0].onClick.AddListener(Button1Function);
            buttons[1].onClick.AddListener(Button2Function);
            buttons[2].onClick.AddListener(Button3Function);
            buttons[3].onClick.AddListener(Button4Function);
        }

    }

    public void Button1Function()
    {
        if(Inventory.LossItem("나무(건설 +10)", 1))
        {
            Inventory.GetItem(Items[4]);
        }
    }

    public void Button2Function()
    {
        if (Inventory.LossItem("딸기(허기 +10)", 1))
        {
            Inventory.GetItem(Items[5]);
            Inventory.GetItem(Items[5]);
        }
    }

    public void Button3Function()
    {
        if (Inventory.LossItem("선인장(건설 +5)", 1))
        {
            Inventory.GetItem(Items[4]);
        }
    }

    public void Button4Function()
    {
        if (Inventory.LossItem("대추야자(허기 +10)", 1))
        {
            Inventory.GetItem(Items[6]);
            Inventory.GetItem(Items[6]);
            Inventory.GetItem(Items[6]);
        }
    }
}
