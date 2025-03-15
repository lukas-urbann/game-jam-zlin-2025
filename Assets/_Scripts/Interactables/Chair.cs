using GJ25.Interface;
using UnityEngine;

namespace GJ25.Interactables
{
    public class Chair : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            Debug.Log($"{gameObject.name} interact");
        }

        public void InteractHoverShow()
        {
            Debug.Log($"{gameObject.name} show");
        }

        public void InteractHoverStay()
        {
            Debug.Log($"{gameObject.name} stay");
        }

        public void InteractHoverHide()
        {
            Debug.Log($"{gameObject.name} hide");
        }
    }
}
