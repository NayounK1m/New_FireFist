using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ä�� ĵ���� �޴� ��Ʈ�ѷ� UI
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
