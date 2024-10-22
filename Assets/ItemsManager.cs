using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsManager : MonoBehaviour
{
    public int[] listIntOfItemNumber; // ������ ��ȣ ����Ʈ

    public List<Text> listTextsOfItemBag; // ������ �ؽ�Ʈ ����Ʈ

    // ������ ������
    private Dictionary<int, string> itemData = new Dictionary<int, string>()
    {
        { 0, "���߾���" },
        { 1, "���" },
        { 2, "���" },
        { 3, "�ٿ��䳪��" },
        { 4, "������" }
    };

    private void Start()
    {
        AddNumber(3); // Ư�� ���� �߰� ����
    }

    private void Update()
    {
        UpdateTextListValues(); // �ؽ�Ʈ ����Ʈ ������Ʈ ����
    }

    // �ؽ�Ʈ ����Ʈ ������Ʈ �Լ�
    public void UpdateTextListValues()
    {
        for (int i = 0; i < listTextsOfItemBag.Count; i++)
        {
            int itemNumber = listIntOfItemNumber[i]; // �ش� �ε����� ������ ��ȣ ��������

            if (itemData.ContainsKey(itemNumber)) // ������ �����Ϳ� �ش� ��ȣ�� �ִ� ���
            {
                listTextsOfItemBag[i].text = itemData[itemNumber]; // �ش� ������ �������� �̸����� �ؽ�Ʈ ������Ʈ
            }
            else // ������ �����Ϳ� �ش� ��ȣ�� ���� ��� (�� ĭ)
            {
                listTextsOfItemBag[i].text = "��ĭ"; // �ؽ�Ʈ�� "��ĭ"���� ǥ��
            }
        }
    }

    // Ư�� ���� �߰� �Լ�
    private void AddNumber(int number)
    {
        int emptyIndex = System.Array.IndexOf(listIntOfItemNumber, -1); // �� ĭ(-1) ã��

        if (emptyIndex != -1) // �� ĭ�� �ִ� ���
        {
            listIntOfItemNumber[emptyIndex] = number; // �ش� ��ġ�� ���� �߰�
            System.Array.Sort(listIntOfItemNumber); // �迭 ����
        }
    }

    // Ư�� ���� ���� �Լ�
    private void RemoveNumber(int number)
    {
        for (int i = 0; i < listIntOfItemNumber.Length; i++)
        {
            if (listIntOfItemNumber[i] == number) // Ư�� ���ڸ� ã�� ���
            {
                for (int j = i; j < listIntOfItemNumber.Length - 1; j++)
                {
                    listIntOfItemNumber[j] = listIntOfItemNumber[j + 1]; // �� ��ҵ��� ������ �̵��Ͽ� ����
                }
                listIntOfItemNumber[listIntOfItemNumber.Length - 1] = -1; // -1�� �����Ͽ� �� ���������� ���
                break;
            }
        }
    }
}
