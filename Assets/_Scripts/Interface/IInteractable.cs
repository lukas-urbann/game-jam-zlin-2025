using GJ25.Player;
using UnityEngine;

namespace GJ25.Interface
{
    public interface IInteractable
    {
        void Interact(PlayerBase player);
        void InteractHoverShow(PlayerBase player);
        void InteractHoverStay(PlayerBase player);
        void InteractHoverHide(PlayerBase player);
    }
}