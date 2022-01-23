using UnityEngine;
using Photon.Voice.PUN;

public class VoiceManager : MonoBehaviour
{
    private PhotonVoiceNetwork punVoiceNetwork;

    void Start()
    {
        punVoiceNetwork = PhotonVoiceNetwork.Instance;
        punVoiceNetwork.Disconnect();
    }
}