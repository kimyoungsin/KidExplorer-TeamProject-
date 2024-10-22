using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed = 5f;
    public float SprintScale = 1.5f;
    public float HungerConsumptionRate = 1f; // 허기 소모량 비율
    //public float HealthConsumptionRate = 0.5f; // 체력 소모량 비율
    public bool isSprinting = false;
    public bool MoveStop = false;
    public bool isPickup;
    public bool isOpen; // 상자 오픈 가능한지

    public UIScript UItext;
    public Inventory inventory;
    public MultipleChoice ChoiceUI;


    public float h;
    public float v;
    private Vector3 vel;

    public Rigidbody rigid;
    public Animator Anim;

    public LayerMask ItemLayer;
    public GameObject ItemObject;

    public GameObject BoxObject;
    public BoxScript Box;



    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        //Anim = GetComponent<Animator>();
        UItext = FindObjectOfType<UIScript>();
        inventory = FindObjectOfType<Inventory>();
        ChoiceUI = FindObjectOfType<MultipleChoice>();

    }

    private void Update()
    {
        if (MoveStop == false)
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");

            vel = new Vector3(h, 0, v).normalized * MovementSpeed;

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                isSprinting = !isSprinting;
            }

            if (isSprinting)
            {
                rigid.velocity = vel * SprintScale;

            }
            else
            {
                rigid.velocity = vel;

            }



            if (Input.GetKeyDown(KeyCode.E))
            {
                PickupItem();
                PickupBox();
            }
        }

        if (h != 0 || v != 0)
        {
            Anim.SetBool("IsWalking", true);
            // 방향에 따라 캐릭터의 회전 방향 설정
            Quaternion targetRotation = Quaternion.LookRotation(new Vector3(h, 0, v));
            gameObject2.transform.rotation = Quaternion.Lerp(gameObject2.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
        else
        {
            Anim.SetBool("IsWalking", false);
        }
    }
    public GameObject gameObject2;
    public float rotationSpeed;

    public void StopMove()
    {
        if (MoveStop == true)
        {
            MoveStop = false;
        }
        else if (MoveStop == false)
        {
            MoveStop = true;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            isPickup = true;
            ItemObject = collision.gameObject;
            UItext.Interaction = collision.GetComponent<ItemScript>().item.ItemName;
        }
        if (collision.gameObject.CompareTag("House"))
        {
            inventory.isBuild = true;
            UItext.Interaction = collision.GetComponent<House>().HouseName;
        }
        if (collision.gameObject.CompareTag("Box"))
        {
            isOpen = true;
            BoxObject = collision.gameObject;
            UItext.Interaction = collision.GetComponent<BoxScript>().BoxName;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            isPickup = false;
            ItemObject = null;
            UItext.Interaction = "";
        }
        if (collision.gameObject.CompareTag("House"))
        {
            inventory.isBuild = false;
            UItext.Interaction = "";
        }
        if (collision.gameObject.CompareTag("Box"))
        {
            isOpen = false;
            UItext.Interaction = "";
        }
    }



    public void PickupItem()
    {
        if (isPickup)
        {
            SoundManager.SharedInstance.PlaySE("Picking");
            vel = new Vector3(0, 0, 0).normalized * 0;
            rigid.velocity = vel * 0;
            MoveStop = true;
            StartCoroutine(PickingItem(ItemObject.transform.GetComponent<ItemScript>().item.GettingTime, ItemObject.transform.GetComponent<ItemScript>().item));
            isPickup = false;
            UItext.Interaction = "채칩중...";
        }
    }

    public IEnumerator PickingItem(float gettingtime, Items items)
    {
        yield return new WaitForSeconds(gettingtime);
        //inventory.GetItem(ItemObject.transform.GetComponent<ItemScript>().item);
        inventory.GetItem(items);
        Destroy(ItemObject);
        UItext.Interaction = "";
        MoveStop = false;
    }

    public void PickupBox()
    {
        if (isOpen)
        {
            Box = BoxObject.transform.GetComponent<BoxScript>();
            UItext.Interaction = "";
            ChoiceUI.ChoiceOn(Box);
            isOpen = false;
        }
    }
}
