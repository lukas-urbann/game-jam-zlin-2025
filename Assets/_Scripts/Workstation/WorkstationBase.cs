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

        public void InteractHoverShow()
        {
            throw new System.NotImplementedException();
        }

        public void InteractHoverStay()
        {
            throw new System.NotImplementedException();
        }

        public void InteractHoverHide()
        {
            throw new System.NotImplementedException();
        }
    }
}
