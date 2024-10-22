using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public UIScript UItext;
    public Items item;


    void Start()
    {
        UItext = FindObjectOfType<UIScript>();
    }


  

}
