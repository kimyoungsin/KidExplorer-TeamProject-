using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageData : MonoBehaviour
{
    public string BGM_Name;

    void Start()
    {
        SoundManager.SharedInstance.PlayBGM(BGM_Name);
    }


    void Update()
    {

    }
}
