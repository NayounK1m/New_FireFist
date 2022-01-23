using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;
using System.IO;
using System.Net;
using System.Text;

//WCF 연결 및 UI
public class WCF : MonoBehaviourPunCallbacks
{
    public GameObject Char1;
    public GameObject Char2;
    public GameObject Char3;
    public GameObject Char4;
    public GameObject Char5;
    public GameObject Char6;
    public GameObject Char7;
    public GameObject Char8;
    public GameObject Char9;
    public GameObject Char10;
    public GameObject Char11;
    public GameObject Char12;


    public GameObject FirstPanel;
    public GameObject SecondPanel;
    public GameObject BtnSet_M;
    public GameObject BtnSet_F;

    public enum Custom
    {
        male1,
        male2,
        male3,
        male4,
        male5,
        male6,
        female1,
        female2,
        female3,
        female4,
        female5,
        female6,
    };

    public static Custom  custom;

    //DB 서비스 url
    public static string url = "http://localhost:59755/StudentService.svc/";

    public static int UserID = 11111111;
    public static string Name;
    public static int Character;

    private static bool Check = false;

    void Awake()
    {
        if(Check == false)
        {
            GetPlayerData();
        }
        else
        {
            return;
        }
    }

    public override void OnDisable()
    {
        Gameunjoin();
    }

    private void GetPlayerData()
    {
        string sendurl = url + "Stu_GameJoin";

        HttpWebRequest httpWebRequest = WebRequest.Create(new Uri(sendurl)) as HttpWebRequest;
        httpWebRequest.Method = "PUT";
        httpWebRequest.ContentType = "application/json; charset=utf-8";

        string msg = "{\"id\":" + UserID + "}";

        byte[] bytes = Encoding.UTF8.GetBytes(msg);
        httpWebRequest.ContentLength = (long)bytes.Length;
        using (Stream requestStream = httpWebRequest.GetRequestStream())
            requestStream.Write(bytes, 0, bytes.Length);

        string result = null;
        try
        {
            using (HttpWebResponse response = httpWebRequest.GetResponse() as HttpWebResponse)
                result = new StreamReader(response.GetResponseStream()).ReadToEnd().ToString();

            string[] result2 = result.Split('"');

            string[] player = result2[1].Split('@');
            //이름 받아오기
            Name = player[1];
            Character = int.Parse(player[2]);

            switch(Character)
                {
                    case 1:
                    FirstPanel.SetActive(false);
                    Char1.SetActive(true);
                    BtnSet_M.SetActive(true);
                    custom = Custom.male1;
                    Check = true;
                    break;

                    case 2:
                    FirstPanel.SetActive(false);
                    Char2.SetActive(true);
                    BtnSet_M.SetActive(true);
                    custom = Custom.male2;
                    Check = true;
                    break;

                    case 3:
                    FirstPanel.SetActive(false);
                    Char3.SetActive(true);
                    BtnSet_M.SetActive(true);
                    custom = Custom.male3;
                    Check = true;
                    break;

                    case 4:
                    FirstPanel.SetActive(false);
                    Char4.SetActive(true);
                    BtnSet_M.SetActive(true);
                    custom = Custom.male4;
                    Check = true;
                    break;

                    case 5:
                    FirstPanel.SetActive(false);
                    Char5.SetActive(true);
                    BtnSet_M.SetActive(true);
                    custom = Custom.male5;
                    Check = true;
                    break;

                    case 6:
                    FirstPanel.SetActive(false);
                    Char6.SetActive(true);
                    BtnSet_M.SetActive(true);
                    custom = Custom.male6;
                    Check = true;
                    break;

                    case 7:
                    FirstPanel.SetActive(false);
                    Char7.SetActive(true);
                    BtnSet_F.SetActive(true);
                    custom = Custom.female1;
                    Check = true;
                    break;

                    case 8:
                    FirstPanel.SetActive(false);
                    Char8.SetActive(true);
                    BtnSet_F.SetActive(true);
                    custom = Custom.female2;
                    Check = true;
                    break;

                    case 9:
                    FirstPanel.SetActive(false);
                    Char9.SetActive(true);
                    BtnSet_F.SetActive(true);
                    custom = Custom.female3;
                    Check = true;
                    break;

                    case 10:
                    FirstPanel.SetActive(false);
                    Char10.SetActive(true);
                    BtnSet_F.SetActive(true);
                    custom = Custom.female4;
                    Check = true;
                    break;

                    case 11:
                    FirstPanel.SetActive(false);
                    Char11.SetActive(true);
                    BtnSet_F.SetActive(true);
                    custom = Custom.female5;
                    Check = true;
                    break;
                    
                    case 12:
                    FirstPanel.SetActive(false);
                    Char12.SetActive(true);
                    BtnSet_F.SetActive(true);
                    custom = Custom.female6;
                    Check = true;
                    break;
                }
        }
        catch
        {
            Application.Quit();
        }
    }

    private void Gameunjoin()
    {
        string sendurl = url + "Ply_GameUnjoin";

        //송신
        HttpWebRequest httpWebRequest = WebRequest.Create(new Uri(sendurl)) as HttpWebRequest;
        httpWebRequest.Method = "PUT";
        httpWebRequest.ContentType = "application/json; charset=utf-8";

        //메시지 형식 : {"id":int"}
        string msg = "{\"id\":" + UserID + "}";

        byte[] bytes = Encoding.UTF8.GetBytes(msg);
        httpWebRequest.ContentLength = (long)bytes.Length;
        using (Stream requestStream = httpWebRequest.GetRequestStream())
            requestStream.Write(bytes, 0, bytes.Length);

        string result = null;
        try
        {
            using (HttpWebResponse response = httpWebRequest.GetResponse() as HttpWebResponse)
                result = new StreamReader(response.GetResponseStream()).ReadToEnd().ToString();

            if (result == "\"[게임 종료 성공]\"")
            {
                //프로그램 종료
                Debug.Log(result);
            }
        }
        catch
        {
            Debug.Log(result);
        }
    }

    private void CustomUpdate(int SelCustom)
    {
        try
        {
            string sendurl = url + "Ply_InputCustom";

            // 송신
            HttpWebRequest httpWebRequest = WebRequest.Create(new Uri(sendurl)) as HttpWebRequest;
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/json; charset=utf-8";

            // 메시지 형식 : {"id":int,"custom":int}
            string msg = "{\"id\":" + UserID + ",\"custom\":" + SelCustom + "}";

            byte[] bytes = Encoding.UTF8.GetBytes(msg);
            httpWebRequest.ContentLength = (long)bytes.Length;
            using (Stream requestStream = httpWebRequest.GetRequestStream())
                requestStream.Write(bytes, 0, bytes.Length);

            // 수신
            string result;
            using (HttpWebResponse response = httpWebRequest.GetResponse() as HttpWebResponse)
                result = new StreamReader(response.GetResponseStream()).ReadToEnd().ToString();

            Debug.Log(result);
        }

        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }

    public void PrevBtn()
    {
        BtnSet_F.SetActive(false);
        BtnSet_M.SetActive(false);
        SecondPanel.SetActive(true);
        Char1.SetActive(false);
        Char2.SetActive(false);
        Char3.SetActive(false);
        Char4.SetActive(false);
        Char5.SetActive(false);
        Char6.SetActive(false);
        Char7.SetActive(false);
        Char8.SetActive(false);
        Char9.SetActive(false);
        Char10.SetActive(false);
        Char11.SetActive(false);
        Char12.SetActive(false);
    }

    public void FinBtn()
    {   
        BtnSet_F.SetActive(false);
        BtnSet_M.SetActive(false);
        SecondPanel.SetActive(false);
        Char1.SetActive(false);
        Char2.SetActive(false);
        Char3.SetActive(false);
        Char4.SetActive(false);
        Char5.SetActive(false);
        Char6.SetActive(false);
        Char7.SetActive(false);
        Char8.SetActive(false);
        Char9.SetActive(false);
        Char10.SetActive(false);
        Char11.SetActive(false);
        Char12.SetActive(false);
    }

    public void ToFirstPanel()
    {
        SecondPanel.SetActive(false);
        FirstPanel.SetActive(true);
    }

    public void ExitBtn()
    {
        SecondPanel.SetActive(false);
        Char1.SetActive(false);
        Char2.SetActive(false);
        Char3.SetActive(false);
        Char4.SetActive(false);
        Char5.SetActive(false);
        Char6.SetActive(false);
        Char7.SetActive(false);
        Char8.SetActive(false);
        Char9.SetActive(false);
        Char10.SetActive(false);
        Char11.SetActive(false);
        Char12.SetActive(false);
        BtnSet_F.SetActive(false);
        BtnSet_M.SetActive(false);
    }

    public void MaleBtnClick1()
    {
        CustomUpdate(1);
        SecondPanel.SetActive(false);
        Char1.SetActive(true);
        BtnSet_M.SetActive(true);
        custom = Custom.male1;
    }

    public void MaleBtnClick2()
    {
        CustomUpdate(2);
        SecondPanel.SetActive(false);
        Char2.SetActive(true);
        BtnSet_M.SetActive(true);
        custom = Custom.male2;
    }

    public void MaleBtnClick3()
    {
        CustomUpdate(3);
        SecondPanel.SetActive(false);
        Char3.SetActive(true);
        BtnSet_M.SetActive(true);
        custom = Custom.male3;
    }

    public void MaleBtnClick4()
    {
        CustomUpdate(4);
        SecondPanel.SetActive(false);
        Char4.SetActive(true);
        BtnSet_M.SetActive(true);
        custom = Custom.male4;
    }

    public void MaleBtnClick5()
    {
        CustomUpdate(5);
        SecondPanel.SetActive(false);
        Char5.SetActive(true);
        BtnSet_M.SetActive(true);
        custom = Custom.male5;
    }

    public void MaleBtnClick6()
    {
        CustomUpdate(6);
        SecondPanel.SetActive(false);
        Char6.SetActive(true);
        BtnSet_M.SetActive(true);
        custom = Custom.male6;
    }
    public void FemaleBtnClick1()
    {
        CustomUpdate(7);
        SecondPanel.SetActive(false);
        Char7.SetActive(true);
        BtnSet_F.SetActive(true);
        custom = Custom.female1;
    }

    public void FemaleBtnClick2()
    {
        CustomUpdate(8);
        SecondPanel.SetActive(false);
        Char8.SetActive(true);
        BtnSet_F.SetActive(true);
        custom = Custom.female2;
    }

    public void FemaleBtnClick3()
    {
        CustomUpdate(9);
        SecondPanel.SetActive(false);
        Char9.SetActive(true);
        BtnSet_F.SetActive(true);
        custom = Custom.female3;
    }

    public void FemaleBtnClick4()
    {
        CustomUpdate(10);
        SecondPanel.SetActive(false);
        Char10.SetActive(true);
        BtnSet_F.SetActive(true);
        custom = Custom.female4;
    }

    public void FemaleBtnClick5()
    {
        CustomUpdate(11);
        SecondPanel.SetActive(false);
        Char11.SetActive(true);
        BtnSet_F.SetActive(true);
        custom = Custom.female5;
    }

    public void FemaleBtnClick6()
    {
        CustomUpdate(12);
        SecondPanel.SetActive(false);
        Char12.SetActive(true);
        BtnSet_F.SetActive(true);
        custom = Custom.female6;
    }
}
