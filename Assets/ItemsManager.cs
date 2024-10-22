using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsManager : MonoBehaviour
{
    public int[] listIntOfItemNumber; // 아이템 번호 리스트

    public List<Text> listTextsOfItemBag; // 아이템 텍스트 리스트

    // 아이템 데이터
    private Dictionary<int, string> itemData = new Dictionary<int, string>()
    {
        { 0, "대추야자" },
        { 1, "멜론" },
        { 2, "사암" },
        { 3, "바오밥나무" },
        { 4, "선인장" }
    };

    private void Start()
    {
        AddNumber(3); // 특정 숫자 추가 예시
    }

    private void Update()
    {
        UpdateTextListValues(); // 텍스트 리스트 업데이트 예시
    }

    // 텍스트 리스트 업데이트 함수
    public void UpdateTextListValues()
    {
        for (int i = 0; i < listTextsOfItemBag.Count; i++)
        {
            int itemNumber = listIntOfItemNumber[i]; // 해당 인덱스의 아이템 번호 가져오기

            if (itemData.ContainsKey(itemNumber)) // 아이템 데이터에 해당 번호가 있는 경우
            {
                listTextsOfItemBag[i].text = itemData[itemNumber]; // 해당 아이템 데이터의 이름으로 텍스트 업데이트
            }
            else // 아이템 데이터에 해당 번호가 없는 경우 (빈 칸)
            {
                listTextsOfItemBag[i].text = "빈칸"; // 텍스트를 "빈칸"으로 표시
            }
        }
    }

    // 특정 숫자 추가 함수
    private void AddNumber(int number)
    {
        int emptyIndex = System.Array.IndexOf(listIntOfItemNumber, -1); // 빈 칸(-1) 찾기

        if (emptyIndex != -1) // 빈 칸이 있는 경우
        {
            listIntOfItemNumber[emptyIndex] = number; // 해당 위치에 숫자 추가
            System.Array.Sort(listIntOfItemNumber); // 배열 정렬
        }
    }

    // 특정 숫자 제거 함수
    private void RemoveNumber(int number)
    {
        for (int i = 0; i < listIntOfItemNumber.Length; i++)
        {
            if (listIntOfItemNumber[i] == number) // 특정 숫자를 찾은 경우
            {
                for (int j = i; j < listIntOfItemNumber.Length - 1; j++)
                {
                    listIntOfItemNumber[j] = listIntOfItemNumber[j + 1]; // 뒷 요소들을 앞으로 이동하여 제거
                }
                listIntOfItemNumber[listIntOfItemNumber.Length - 1] = -1; // -1로 설정하여 빈 아이템으로 취급
                break;
            }
        }
    }
}
