using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//플레이어 닉네임 연결
public class PlayerNickname : MonoBehaviourPunCallbacks
{
    public TextMesh Nickname;
    public PhotonView pv;
    private void Start()
    {
        if(pv.IsMine)
        {
            gameObject.SetActive(false);
        }

        Nickname.text = pv.Owner.NickName;
    }
}
