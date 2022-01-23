using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//사서 클릭 UI  
public class NPCCtrl : MonoBehaviour
{
    private GameObject target;
    public GameObject Panel;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = GetClickedObject();

            if (target.Equals(gameObject))
            {
                Panel.SetActive(true);
            }
        }
    }

    private GameObject GetClickedObject()
    {
        RaycastHit hit;
        GameObject target = null;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);      //마우스 포인트 근처 좌표를 만든다.
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))     //마우스 근처에 오브젝트가 있는지 확인
        {
            target = hit.collider.gameObject;
        }
        return target;
    }
}
