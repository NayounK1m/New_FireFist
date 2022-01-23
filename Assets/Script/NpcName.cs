using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�缭 TMP Ʈ���� UI 
public class NPCName : MonoBehaviour
{
    public GameObject MeetingRoom;
    public GameObject Library;

    public GameObject Activate;
    public GameObject DeActivate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            MeetingRoom.SetActive(true);
            Library.SetActive(true);
            Activate.SetActive(false);
            DeActivate.SetActive(true);
        }       
    }
}
