using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public Text TimeText;
    public float TimeCount = 60;
    public Image HungerMeter;
    public Text HungerText;
    public float Hunger = 100;
    public float MaxHunger = 100;
    public Text InteractionText;
    public string Interaction;
    public Text BulidImprovementText;
    public int BulidImprovement = 0;
    public bool isGameover;
    public bool isGameClear;
    public bool isStopMeter; //���� ���� ���� �ð� ���� �����

    public GameObject StageClearText;
    public Inventory inventory;
    public PlayerMovement player;
    public GameObject InventoryObj;
    public GameObject ChoiceObj;
    public House HouseObj;

    public PlayerMovement PlayerMovement;
    public GameObject @object;

    public int targetSceneIndex; // Ȱ��ȭ�� ���� �ε���
    //public GameObject targetObject1; // Ȱ��ȭ/��Ȱ��ȭ�� ������Ʈ
    //p/ublic GameObject targetObject2; // Ȱ��ȭ/��Ȱ��ȭ�� ������Ʈ


    void Awake()
    {
        player = FindObjectOfType<PlayerMovement>();
        inventory = FindObjectOfType<Inventory>();
        HouseObj = FindObjectOfType<House>();
        PlayerMovement = FindObjectOfType<PlayerMovement>();

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == targetSceneIndex)
        {
            //targetObject1.SetActive(true); // ������Ʈ Ȱ��ȭ
            //targetObject2.SetActive(false); // ������Ʈ Ȱ��ȭ
        }
        else
        {
            //targetObject1.SetActive(false); // ������Ʈ ��Ȱ��ȭ
            //targetObject2.SetActive(true); // ������Ʈ ��Ȱ��ȭ
        }
    }


    void Update()
    {
        if(Hunger < 0 || TimeCount < 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        HungerMeter.fillAmount = Hunger / MaxHunger;

        if(!isGameClear && !isGameover)
        {
            if (TimeCount >= 0 && !isStopMeter)
            {
                TimeTextUI();
            }


            if (Hunger >= 0 && !isStopMeter)
            {
                HungerUI();
            }

        }

        if(Hunger > MaxHunger)
        {
            Hunger = MaxHunger;
        }


        InteractionText.text = "" + Interaction.ToString();
        BulidImprovementText.text = "�Ǽ���: " + BulidImprovement;

        if(isGameover)
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                isGameClear = false;
                Hunger = MaxHunger;
                TimeCount = 60;
                SceneManager.LoadScene(0);        //����Ű ������ Ÿ��Ʋ ȭ������
            }
        }

    }

    public void TimeTextUI()
    {
        TimeCount -= Time.deltaTime;

        if (TimeCount <= 0)
        {
            player.MoveStop = true;
            inventory.InventoryActive = !inventory.InventoryActive;
            inventory.InventoryBase.SetActive(false);
            TimeText.text = "Ÿ�ӿ���.";
            InventoryObj.SetActive(false);
            ChoiceObj.SetActive(false);
            isGameover = true;
        }
        else
        {
            TimeText.text = "Time: " + TimeCount;
        }


    }

    public void HungerUI()
    {
        //player.HungerConsumptionRate = 1f;

        Hunger -= player.HungerConsumptionRate * Time.deltaTime;

        if (PlayerMovement.isSprinting == true && (PlayerMovement.h != 0 || PlayerMovement.v != 0))
        {
            Hunger -= player.HungerConsumptionRate * 3f * Time.deltaTime;

        }


        @object.SetActive(PlayerMovement.isSprinting);

        if (Hunger <= 0)
        {
            player.MoveStop = true;
            inventory.InventoryActive = !inventory.InventoryActive;
            inventory.InventoryBase.SetActive(false);
            HungerText.text = "�ƻ��߽��ϴ�.";
            InventoryObj.SetActive(false);
            ChoiceObj.SetActive(false);
            isGameover = true;
        }
    }


    public IEnumerator BuildClear()
    {
        isGameClear = true;
        yield return new WaitForSeconds(1f);
        SoundManager.SharedInstance.PlaySE("BuildClear");
        StageClearText.SetActive(true);
        player.MoveStop = true;
        inventory.InventoryActive = !inventory.InventoryActive;
        inventory.InventoryBase.SetActive(false);
        StartCoroutine(NextSceneMove());
    }


    public IEnumerator NextSceneMove()
    {
        yield return new WaitForSeconds(3f);
        player.MoveStop = false;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }   //���� �� �̵�
    }
}
