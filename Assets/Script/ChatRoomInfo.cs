using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;
using Photon.Realtime;
public class ChatRoomInfo : MonoBehaviourPunCallbacks
{
     public TMP_Text roomName;
     public TMP_Text playerCount;

    void Awake()
    {
        SetRoomInfo();
    }

    void SetRoomInfo()
    {
        Room room = PhotonNetwork.CurrentRoom;
        roomName.text = room.Name;

        playerCount.text = $"({room.PlayerCount}/{room.MaxPlayers})";
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        SetRoomInfo();
    }

    //룸에서 네트워크 유저가 퇴장했을 때 호출되는 콜백 함수
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        SetRoomInfo();
    }

}
