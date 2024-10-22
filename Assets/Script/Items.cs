using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]

public class Items : ScriptableObject
{
    public Sprite ItemSprite;
    public string ItemName;
    public int BuildingPlus; // �� ������
    public float HungerPlus; // ��� ������ ȸ����

    public float GettingTime; //��µ� �ɸ��� �ð�

    public ItemType itemtype;
    public enum ItemType
    {
        Eatable,
        BuildItem,
        ETC
    }
}
