using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Sprite[] sprite;
    public Image image;
    public bool InventoryActive = false;
    public GameObject InventoryBase;

    public Image[] ItemImage;
    public Sprite NoneSprite;
    public Items[] ItemSlot;
    public int[] ItemCount;
    public int SelectNum;
    public Text ItemCountText;
    public Text ItemNameText;

    public UIScript uiscript;
    public PlayerMovement player;
    public bool isBuild;

    public House HouseObj;

    public PlayerMovement PlayerMovement;

    void Start()
    {
        uiscript = FindObjectOfType<UIScript>();
        player = FindObjectOfType<PlayerMovement>();
        HouseObj = FindObjectOfType<House>();
        PlayerMovement = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        UseInventoryToggle();


        if (InventoryActive)
        {

            if (Input.GetKeyDown(KeyCode.A))
            {

                if (SelectNum == 0)
                {
                    SelectNum = 6;
                }
                else
                {
                    SelectNum -= 1;
                }
                image.sprite = sprite[SelectNum];
                ItemCountText.text = "개수: " + ItemCount[SelectNum].ToString();
                if(ItemSlot[SelectNum] != null)
                {
                    ItemNameText.text = "" + ItemSlot[SelectNum].ItemName;
                }
              
            }
            if (Input.GetKeyDown(KeyCode.D))
            {

                if (SelectNum == 6)
                {
                    SelectNum = 0;
                }
                else
                {
                    SelectNum += 1;
                }
                image.sprite = sprite[SelectNum];
                ItemCountText.text = "개수: " + ItemCount[SelectNum].ToString();
                if (ItemSlot[SelectNum] != null)
                {
                    ItemNameText.text = "" + ItemSlot[SelectNum].ItemName;
                }

            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (ItemSlot[SelectNum].itemtype == Items.ItemType.Eatable && ItemCount[SelectNum] >= 1)
                {
                    SoundManager.SharedInstance.PlaySE("Eat");
                    uiscript.Hunger += ItemSlot[SelectNum].HungerPlus;
                    ItemCount[SelectNum] -= 1;
                    ItemCountText.text = "개수: " + ItemCount[SelectNum].ToString();
                    if (ItemCount[SelectNum] <= 0) 
                    {
                        ItemImage[SelectNum].sprite = NoneSprite;
                        ItemNameText.text = "";
                    }

                }
                else if (ItemSlot[SelectNum].itemtype == Items.ItemType.BuildItem && ItemCount[SelectNum] >= 1 && isBuild)
                {
                    SoundManager.SharedInstance.PlaySE("Build");
                    uiscript.BulidImprovement += ItemSlot[SelectNum].BuildingPlus;
                    ItemCount[SelectNum] -= 1;
                    ItemCountText.text = "개수: " + ItemCount[SelectNum].ToString();
                    HouseObj.BuildHouse(ItemSlot[SelectNum].BuildingPlus, ItemSlot[SelectNum]);
                    if (ItemCount[SelectNum] <= 0)
                    {
                        ItemImage[SelectNum].sprite = NoneSprite;
                        ItemNameText.text = "";
                    }
                    if (uiscript.BulidImprovement >= 100)
                    {
                        StartCoroutine(uiscript.BuildClear());

                    }
                }


            }

        }


    }

    public void UseInventoryToggle()
    {


        if (Input.GetKeyDown(KeyCode.F) && (PlayerMovement.MoveStop == false || InventoryActive == true))
        {
            

            InventoryActive = !InventoryActive;
            player.StopMove();
            if (InventoryActive)
            {
                OpenInventory();

            }
            else
            {
                CloseInventory();
            }
        }
    }

    public void OpenInventory()
    {
        ItemCountText.text = "개수: " + ItemCount[SelectNum].ToString();
        if (ItemSlot[SelectNum] != null)
        {
            ItemNameText.text = "" + ItemSlot[SelectNum].ItemName;
        }
        InventoryBase.SetActive(true);
    }

    public void CloseInventory()
    {
        InventoryBase.SetActive(false);
    }
    public void GetItem(Items items)
    {
        SoundManager.SharedInstance.PlaySE("ItemPickup");
        for (int i = 0; i <= 6; i++)
        {
            if (ItemSlot[i] != null)
            {
                if (ItemSlot[i].ItemName == items.ItemName)
                {
                    Debug.Log("기존의 아이템에 더함");
                    ItemImage[i].sprite = items.ItemSprite;
                    ItemCount[i] += 1;
                    return;
                }

            }
        }

        for (int i = 0; i <= 6; i++)
        {
            if (ItemSlot[i] == null)
            {
                Debug.Log("아이템 새로 획득");
                ItemSlot[i] = items;
                ItemImage[i].sprite = items.ItemSprite;
                ItemCount[i] += 1;
                return;
            }
        }
    }

    public bool LossItem(string itemName, int count)
    {
        bool itemFound = false;

        for (int i = 0; i < ItemSlot.Length; i++)
        {
            if (ItemSlot[i] != null && ItemSlot[i].ItemName == itemName)
            {
                itemFound = true;
                ItemCount[i] -= count;
                if (ItemCount[i] <= 0)
                {
                    ItemSlot[i] = null;
                    ItemImage[i].sprite = NoneSprite;
                    ItemNameText.text = "";
                }
                ItemCountText.text = "개수: " + ItemCount[SelectNum].ToString();
                break;
            }
        }

        if (!itemFound)
        {
            Debug.Log("The item " + itemName + " does not exist in the inventory.");
   
        }
        return itemFound;
    }



}
