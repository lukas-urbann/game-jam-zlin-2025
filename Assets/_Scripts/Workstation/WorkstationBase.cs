using GJ25.Interface;
using UnityEngine;

namespace GJ25.Workstation
{
    public class WorkstationBase : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            Debug.Log("Interakce");
        }
    }
}
