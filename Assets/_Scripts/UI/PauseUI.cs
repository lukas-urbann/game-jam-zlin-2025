using UnityEngine;

namespace GJ25.UI
{
    public class PauseUI : MonoBehaviour
    {
        public KeyCode pauseBtn;
        public GameObject pauseUI;

        public void Toggle()
        {
            pauseUI.SetActive(!pauseUI.activeSelf);
            Time.timeScale = pauseUI.activeSelf ? 0 : 1;
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(pauseBtn))
            {
                Toggle();
            }
        }
    }
}

