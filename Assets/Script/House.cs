using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    public UIScript UItext;

    public string HouseName;

    public GameObject[] HouseBuilds;
    public int BulidImprovement;

    public Items[] NeedObjs;
    public int[] NeedNum;

    void Start()
    {
        UItext = FindObjectOfType<UIScript>();
    }

    void Update()
    {
        
    }

    public void BuildHouse(int build, Items items)
    {
        BulidImprovement += build;
        if(BulidImprovement >= 50 && BulidImprovement < 99)
        {
            HouseBuilds[0].SetActive(false);
            HouseBuilds[1].SetActive(true);
            
        }
        else if(BulidImprovement >= 100)
        {
            HouseBuilds[0].SetActive(false);
            HouseBuilds[1].SetActive(false);
            HouseBuilds[2].SetActive(true);
        }
    }

}
