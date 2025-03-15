using UnityEngine;


namespace GJ25.Interactables
{
    public class Chair : InteractableObjectBase
    {
        public void Test()
        {
            Debug.Log("Testing .." + this.name);
            AudioManager audioManager = FindFirstObjectByType<AudioManager>();
            audioManager.Play("Test");
        }
    }
}