using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{

    public UIScript UItext;
    public Inventory inventory;

    public string BoxName;
    public Items PositiveItem; //�������� ȿ���� ��� ������
    public Items NegatievLossItem; //�������� ȿ���� �Ҵ� ������
    public float PositivePlusHunger; //�������� ȿ���� ��� ��ⷮ
    public float NegatievLossHunger; //�������� ȿ���� �Ҵ� ��ⷮ
    public int rand;



    void Start()
    {
        rand = Random.Range(0, 3); // 0: ����ȿ��, 1: �ƹ�ȿ�� ����, 2: ����ȿ��
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
