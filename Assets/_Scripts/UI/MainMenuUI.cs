using UnityEngine;

namespace GJ25.UI
{
    public class MainMenuUI : MonoBehaviour
    {
        public string musicName = "bgm";
        
        private void Start()
        {
            AudioManager.instance.Play(musicName);
        }
    }
}
