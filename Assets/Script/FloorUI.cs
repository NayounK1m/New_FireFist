using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1,2�� ��� UI ����
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
