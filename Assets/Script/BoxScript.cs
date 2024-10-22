using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{

    public UIScript UItext;
    public Inventory inventory;

    public string BoxName;
    public Items PositiveItem; //긍정적인 효과시 얻는 아이템
    public Items NegatievLossItem; //부정적인 효과시 잃는 아이템
    public float PositivePlusHunger; //긍정적인 효과시 얻는 허기량
    public float NegatievLossHunger; //부정적인 효과시 잃는 허기량
    public int rand;



    void Start()
    {
        rand = Random.Range(0, 3); // 0: 부정효과, 1: 아무효과 없음, 2: 긍정효과
        inventory = FindObjectOfType<Inventory>();
        UItext = FindObjectOfType<UIScript>();

    }

    void Update()
    {
        
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

}
