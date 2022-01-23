using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ä�� ĵ���� �޴� ��Ʈ�ѷ� ���
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
