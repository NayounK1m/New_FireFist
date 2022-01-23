using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//채팅 캔버스 메뉴 컨트롤러 기능
public class MenuManager : MonoBehaviour
{
public static MenuManager Instance;

    [SerializeField] Menu menus;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        menus.Open();
    }
}
