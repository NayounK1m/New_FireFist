using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//채팅 캔버스 메뉴 컨트롤러 UI
public class Menu : MonoBehaviour
{
    public string menuName;
    public bool open;

    public void Open()
    {
        open = true;
        gameObject.SetActive(true);
    }
}
