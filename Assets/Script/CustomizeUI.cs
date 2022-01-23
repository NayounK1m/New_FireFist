using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//커스터마이즈 UI
public class CustomizeUI : MonoBehaviour
{
    public GameObject CPanel;
    public GameObject MPanel;
    public GameObject FPanel;

    public void MaleBtnClick()
    {
        CPanel.SetActive(false);
        MPanel.SetActive(true);
    }

    public void FemaleBtnClick()
    {
        CPanel.SetActive(false);
        FPanel.SetActive(true);
    }

    public void ExitBtnClick()
    {
        CPanel.SetActive(false);
        Application.Quit();
    }
}
