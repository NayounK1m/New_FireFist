using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBookUI : MonoBehaviour
{
    public GameObject EbookPanel;

    public GameObject InfoPanel;

    public void ExitBtn()
    {
        EbookPanel.SetActive(false);
    }

    public void RentBtn()
    {

    }

    public void ReturBtn()
    {

    }

    public void InfoBtn()
    {
        InfoPanel.SetActive(true);
    }
    public void InfoExit()
    {
        InfoPanel.SetActive(false);
    }
}
