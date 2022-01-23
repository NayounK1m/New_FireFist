
//포톤 보이스 토글 컨트롤러
namespace ExitGames.Demos.DemoPunVoice 
{
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Toggle))]
    [DisallowMultipleComponent]
    public class BetterToggle : MonoBehaviour 
    {
        private Toggle toggle;

        public delegate void OnToggle(Toggle toggle);

        public static event OnToggle ToggleValueChanged;

        private void Start() 
        {
            this.toggle = this.GetComponent<Toggle>();
            this.toggle.onValueChanged.AddListener(delegate { this.OnToggleValueChanged(); });
        }

        public void OnToggleValueChanged() 
        {
            if (ToggleValueChanged != null) 
                ToggleValueChanged(this.toggle);
        }
    }
}