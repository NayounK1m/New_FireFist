using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1,2Ãþ °è´Ü UI ·ÎÁ÷
public class FloorUI : MonoBehaviour
{
    public GameObject FloorPanel;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FloorPanel.SetActive(true);
        }
    }
}
