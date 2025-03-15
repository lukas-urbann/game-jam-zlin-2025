using GJ25.Interface;
using GJ25.Player;
using UnityEngine;
using UnityEngine.Events;

namespace GJ25.Interactables
{
    public class InteractableObjectBase : MonoBehaviour, IInteractable
    {
        public UnityEvent<PlayerBase> onInteract = new();
        public UnityEvent<PlayerBase> onInteractHoverShow = new();
        public UnityEvent<PlayerBase> onInteractHoverStay = new();
        public UnityEvent<PlayerBase> onInteractHoverHide = new();

        public void Interact(PlayerBase player) => onInteract.Invoke(player);
        public void InteractHoverShow(PlayerBase player) => onInteractHoverShow.Invoke(player);
        public void InteractHoverStay(PlayerBase player) => onInteractHoverStay.Invoke(player);
        public void InteractHoverHide(PlayerBase player) => onInteractHoverHide.Invoke(player);
    }
}
