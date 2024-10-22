using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]

public class Items : ScriptableObject
{
    public Sprite ItemSprite;
    public string ItemName;
    public int BuildingPlus; // 집 수리량
    public float HungerPlus; // 허기 게이지 회복량

    public float GettingTime; //얻는데 걸리는 시간

    public ItemType itemtype;
    public enum ItemType
    {
        Eatable,
        BuildItem,
        ETC
    }
}
