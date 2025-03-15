using UnityEngine;

namespace GJ25.Interface
{
    public interface IInteractable
    {
        void Interact();
        void InteractHoverShow();
        void InteractHoverStay();
        void InteractHoverHide();
    }
}