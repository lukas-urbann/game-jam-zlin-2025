using UnityEngine;

namespace GJ25.Audio
{
    public class AudioCall : MonoBehaviour
    {
        public void PlaySound(string name)
        {
            AudioManager.instance.Play(name);
        }

        public void PlayRandomSound(string name)
        {
            string[] options = name.Split(',');
            PlaySound(options[Random.Range(0, options.Length)]);
        }
    }
}
