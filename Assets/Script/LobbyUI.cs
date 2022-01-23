using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUI : MonoBehaviour
{
    public GameObject MRPanel;

    public void ExitBtn()
    {
        MRPanel.SetActive(false);
    }
}
