using System;
using UnityEngine;
using UnityEngine.UI;
using Photon.Chat;
using Photon.Pun;
using AuthenticationValues = Photon.Chat.AuthenticationValues;  //UserName을 UserID로 전환

public class ChatManager : MonoBehaviour, IChatClientListener 
{
    private ChatClient chatClient;
    public static string userName = WCF.Name;
  
    string channelName = PhotonNetwork.CurrentRoom.Name;

    public Canvas canvas;
    public Canvas canvas2;

    public InputField inputField;
    public Text outputText;

    public Button btnOn;
    public Button btnOff;

    void Awake()
	{   
        Application.runInBackground = true; //어플리케이션이 실행되고 있을 때 플레이어가 실행해야 하는지 여부 
        chatClient = new ChatClient(this);
        
        //userName ="경호"; //System.Environment.UserName; //이름 입력 받기...

        //chatClient.Connect(앱ID, 버전, 사용자인증)
        chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, "1.0", new AuthenticationValues(userName));    
        AddLine(string.Format("연결시도", userName));
	    canvas.GetComponent<Canvas>().enabled = false;
        canvas2.GetComponent<Canvas>().enabled = true;
    }

    public void DIsConnect()
    {
        UnSubscribe(PhotonNetwork.CurrentRoom.Name);
        chatClient.Disconnect();
    }

    void Update ()
    {
        chatClient.Service();
    }

     public void ButtonOn()
    {
        canvas.GetComponent<Canvas>().enabled = false;
        canvas2.GetComponent<Canvas>().enabled = true;
    }

    public void ButtonOff()
    {
        canvas.GetComponent<Canvas>().enabled = true;
        canvas2.GetComponent<Canvas>().enabled = false;
    }
  
    public void AddLine(string lineString)
    {
        outputText.text += lineString + "\r\n";
    }

    //챗 관련 오류 잡아내는 함수(IChatClientListener 인터페이스)
    public void DebugReturn (ExitGames.Client.Photon.DebugLevel level, string message)
    {
        if (level == ExitGames.Client.Photon.DebugLevel.ERROR)
        {
            Debug.LogError(message);
        }
        else if (level == ExitGames.Client.Photon.DebugLevel.WARNING)
        {
            Debug.LogWarning(message);
        }
        else
        {
            Debug.Log(message);
        }
    }

    //서버연결 콜백
    public void OnConnected ()
    {
        AddLine ("서버에 연결되었습니다.");
        Subscribe(PhotonNetwork.CurrentRoom.Name);
    }

    //서버해제 콜백
    public void OnDisconnected ()
    {
        AddLine ("서버에 연결이 끊어졌습니다.");
        Debug.Log("test");
    }

    //구독하는 채널 이름(필수적) 
    public void Subscribe(string chaName)
    {
        chatClient.Subscribe(new string[] { chaName }, 10);
        
    }
    
    public void UnSubscribe(string chaName)
    {
        this.chatClient.Unsubscribe(new string[] { chaName });
    }


    //채팅 상태(IChatClientListener 인터페이스) 
    public void OnChatStateChange (ChatState state)
    {
        Debug.Log("OnChatStateChange = " + state);
    }

    //채널 입장(IChatClientListener 인터페이스)
    public void OnSubscribed(string[] channels, bool[] results)
    {
        AddLine (string.Format("채널 입장 ({0})", string.Join(",",channels)));
    }

    //채널 퇴장(IChatClientListener 인터페이스)
    public void OnUnsubscribed(string[] channels)
    {
        AddLine (string.Format("채널 퇴장 ({0})", string.Join(",",channels)));
    }

    //메시지 받는 부분(IChatClientListener 인터페이스)
    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        for (int i = 0; i < messages.Length; i++)
		{
		    ReceiveMessages(senders[i], messages[i].ToString());
		}
    }

    //귓속말
    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        ReceiveMessages(sender + "의 귓속말", message.ToString());
    }

    void ReceiveMessages(string nickName, string msg)
    {
        outputText.text += (outputText.text != "" ? "\n" : "") + nickName + " : " + msg;
    }

    void ReceiveMessages(string msg)
    {
        outputText.text += (outputText.text != "" ? "\n" : "") + msg;
    }

    //현재 상태 수신
    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        Debug.Log("status : " + string.Format("{0} is {1}, Msg : {2} ", user, status, message)); 
    }
  
    public void OnEnterSend()
    {
        //2개의 다른 엔터키에 대한 입력
        if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
        {
            if(StringAvailable(inputField.text)) 
                Send(inputField.text);
		      
            this.inputField.text = "";
        }

	}

    //채팅창에 메시지를 입력해야만 보내지게하는 함수
    bool StringAvailable(string s)
    {
        if (string.IsNullOrWhiteSpace(s)) return false;
        return true;
    }

    // 입력한 채팅을 서버로 전송한다.
    void Send(string s)
	{
        //귓속말
		if (s.Contains(">>"))
		{
			string[] ss = s.Split(new string[] { ">>" }, StringSplitOptions.None);
			chatClient.SendPrivateMessage(ss[0], ss[1]);
		}
        //일반채팅
		else 
            chatClient.PublishMessage(channelName, s); 
	}

    #region 인터페이스 메서드
    public void OnApplicationQuit() { }
    public void OnUserSubscribed(string channel, string user) { }
    public void OnUserUnsubscribed(string channel, string user) { }
    #endregion
}
