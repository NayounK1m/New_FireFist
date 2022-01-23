using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//1,2층 계단 트리거 이동 로직
public class FloorButton : MonoBehaviour
{
    public GameObject YButton;
    public GameObject NButton;
    public GameObject FloorUI;

    private GameObject Player;

    public Transform FirstFloor;
    public Transform SecondFloor;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    public void Moveto1F()
    {
        Player.transform.position = FirstFloor.position;
        FloorUI.SetActive(false);
    }

    public void Moveto2F()
    {
        Player.transform.position = SecondFloor.position;
        FloorUI.SetActive(false);
    }

    public void CancleMove()
    {

        FloorUI.SetActive(false);
    }
}
