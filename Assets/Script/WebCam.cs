using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebCam : MonoBehaviour
{
    void Start () {
        WebCamTexture web = new WebCamTexture(1280,720,60);
        GetComponent<MeshRenderer>().material.mainTexture = web;
        web.Play();
    }
}
