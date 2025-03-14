using UnityEngine;
using UnityEngine.SceneManagement;

namespace GJ25.Scenes
{
    public class SceneLoader : MonoBehaviour
    {
        public void ChangeScene(int name)
        {
            SceneManager.LoadScene(name);
        }

        public void EndApp()
        {
            Application.Quit();
        }
    }
}
