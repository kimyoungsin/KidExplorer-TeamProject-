using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultipleChoice : MonoBehaviour
{
    public Sprite[] sprite;
    public Image image;

    public Sprite[] Selectsprite;
    public Image SelectChoiceimage;

    public int ChoiceNum; //0: 예, 1: 아니오
    public int Rand; //0: 부정, 1: 아무효과 없음, 2: 긍정
    public GameObject BoxCouiceObj;
    public GameObject SelectChoiceObj;
    public BoxScript Box;
    public Inventory inventory;
    public PlayerMovement player;
    public UIScript uiscript;
    public bool isChoice = false;
    public bool isChoiceResult = false;

    void Start()
    {
        
        inventory = FindObjectOfType<Inventory>();
        uiscript = FindObjectOfType<UIScript>();
        player = FindObjectOfType<PlayerMovement>();

    }

    
    void Update()
    {
        if(isChoice)  //0: 예, 1: 아니오
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (ChoiceNum == 0)
                {
                    ChoiceNum = 1;
                    SelectChoiceimage.sprite = Selectsprite[1];
                }
                else
                {
                    ChoiceNum = 0;
                    SelectChoiceimage.sprite = Selectsprite[0];
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (ChoiceNum == 1)
                {
                    ChoiceNum = 0;
                    SelectChoiceimage.sprite = Selectsprite[0];
                }
                else
                {
                    ChoiceNum = 1;
                    SelectChoiceimage.sprite = Selectsprite[1];
                }
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(ChoiceNum == 0)
                {
                    SoundManager.SharedInstance.PlaySE("BoxEvent");
                    if (Rand == 0)//부정
                    {
                        image.sprite = sprite[0];
                        uiscript.Hunger -= Box.NegatievLossHunger;
                        isChoice = false;
                        StartCoroutine(ChoiceResult());
                        SelectChoiceObj.SetActive(false);

                    }
                    else if(Rand == 1)// 아무효과없음
                    {
                        image.sprite = sprite[1];
                        isChoice = false;
                        StartCoroutine(ChoiceResult());
                        SelectChoiceObj.SetActive(false);
                    }
                    else if (Rand == 2) // 긍정
                    {
                        image.sprite = sprite[2];
                        inventory.GetItem(Box.PositiveItem);
                        isChoice = false;
                        StartCoroutine(ChoiceResult());
                        SelectChoiceObj.SetActive(false);
                    }
                    
                }
                else
                {
                    uiscript.isStopMeter = false;
                    player.StopMove();
                    isChoice = false;
                    BoxCouiceObj.SetActive(false);
                    SelectChoiceObj.SetActive(false);
                }
            }

    
        }
        if (isChoiceResult && Input.GetKeyDown(KeyCode.E))
        {
            isChoiceResult = false;
            StartCoroutine(ChoiceEnd());
        }
    }

    public void ChoiceOn(BoxScript box)
    {
        uiscript.isStopMeter = true;
        ChoiceNum = 0;
        SelectChoiceimage.sprite = Selectsprite[0];
        image.sprite = sprite[3];
        Box = box;
        Rand = Box.rand;
        player.StopMove();
        StartCoroutine(ChoiceSelect());
        BoxCouiceObj.SetActive(true);
        SelectChoiceObj.SetActive(true);

    }

    public IEnumerator ChoiceSelect()
    {
        yield return new WaitForSeconds(0.1f);
        isChoice = true;
    }

    public IEnumerator ChoiceResult()
    {
        yield return new WaitForSeconds(0.1f);
        isChoiceResult = true;
    }

    public IEnumerator ChoiceEnd()
    {
        yield return new WaitForSeconds(0.1f);
        uiscript.isStopMeter = false;
        Box.Destroy();
        player.StopMove();
        isChoice = false;

        BoxCouiceObj.SetActive(false);
        SelectChoiceObj.SetActive(false);

    }
}
