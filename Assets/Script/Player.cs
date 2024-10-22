using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Hunger = 100;
    public float MaxHunger = 100;
    public float Stamina = 60;
    public float MaxStaminap = 60;
    public int Armor = 0; //방어력
    public float MovementSpeed = 4; //이속

    public bool StaminaRefresh = true;

    static public Player instance;

    SpriteRenderer spriteRenderer;
    public Rigidbody rigid;


    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }


    void Update()
    {
        if (Stamina < MaxStaminap)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {

            }
            else
            {
                if (StaminaRefresh == true)
                {
                    Stamina += 0.1f;
                }

            }
        }



    }

    public void TPRefreshOff()
    {
        CancelInvoke("TPRefreshOn");
        StaminaRefresh = false;
        Invoke("TPRefreshOn", 0.5f);
    }
    public void TPRefreshOn()
    {
        StaminaRefresh = true;
    }




}
