using Photon.Voice.Unity;
using Photon.Voice.PUN;

#pragma warning disable 0649    //0649 오류 무시

//포톤 보이스 관련 로직
namespace ExitGames.Demos.DemoPunVoice
{
    using UnityEngine;
    using UnityEngine.UI;

    public class Mute : MonoBehaviour
    {
        private PhotonVoiceNetwork punVoiceNetwork;
        private float volumeBeforeMute;
        public Recorder recorder;

        [SerializeField]
        private GameObject mutetoggle;

        private void Awake()
        {
            this.punVoiceNetwork = PhotonVoiceNetwork.Instance;
        }

        void Start()
        {
            this.volumeBeforeMute = AudioListener.volume;
            if (this.mutetoggle != null)
            {
                this.mutetoggle.SetActive(true);
                this.InitToggles(this.mutetoggle.GetComponentsInChildren<Toggle>());
            }
            this.punVoiceNetwork.ConnectAndJoinRoom();
        }

        private void OnEnable()
        {
            BetterToggle.ToggleValueChanged += this.BetterToggle_ToggleValueChanged;
        }

        private void OnDisable()
        {          
            BetterToggle.ToggleValueChanged -= this.BetterToggle_ToggleValueChanged; 
                       
        }
        
        private void InitToggles(Toggle[] toggles)
        {
            if (toggles == null)
                return;

            for (int i = 0; i < toggles.Length; i++)
            {
                Toggle toggle = toggles[i];

                
                if(toggle.name=="Mute")
                {
                    toggle.isOn = AudioListener.volume <= 0.001f;
                }
                else if(toggle.name=="Transmit")
                {
                    toggle.isOn = this.recorder != null && this.recorder.TransmitEnabled;
                }
            }
        }

        private void BetterToggle_ToggleValueChanged(Toggle toggle)
        {
            if(toggle.name=="Mute")
            {           
                
                if (toggle.isOn)
                {
                    
                    this.volumeBeforeMute = AudioListener.volume;
                    AudioListener.volume = 0f;
                }

                
                else
                {
                    AudioListener.volume = this.volumeBeforeMute;
                    this.volumeBeforeMute = 0f;
                }
            }

            else if(toggle.name == "Transmit")
            {
                if (this.recorder)
                {
                    this.recorder.TransmitEnabled = toggle.isOn;
                }
            }
        }
    }
}