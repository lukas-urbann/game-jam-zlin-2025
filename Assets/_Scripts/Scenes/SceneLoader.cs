using UnityEngine;
using UnityEngine.SceneManagement;

namespace GJ25.Scenes
{
    public class SceneLoader : MonoBehaviour
    {
        public void ChangeScene(int name)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(name,LoadSceneMode.Single);
        }
        
        public void EndApp()
        {
            Application.Quit();
        }
    }
}
