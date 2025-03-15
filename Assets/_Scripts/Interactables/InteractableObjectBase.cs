using System;
using GJ25.Interface;
using GJ25.Player;
using UnityEngine;
using UnityEngine.Events;

namespace GJ25.Interactables
{
    public class InteractableObjectBase : MonoBehaviour, IInteractable
    {
        //PlayerBase otherPlayer = PlayerQuery.players.FirstOrDefault(p => p != playerBase);
        //if(otherPlayer != null) Debug.Log($"Applying debuff from {playerBase.name} to: {otherPlayer.name}");
        
        private Animator _animator;

        private void EnableHoverAnimation(object _) => _animator.SetBool("hover", true);
        private void DisableHoverAnimation(object _) => _animator.SetBool("hover", false);
        
        
        private void AssignAnimations()
        {
            onInteractHoverShow?.AddListener(EnableHoverAnimation);
            onInteractHoverHide?.AddListener(DisableHoverAnimation);
        }

        private void OnDisable()
        {
            onInteractHoverShow.RemoveAllListeners();
            onInteractHoverHide.RemoveAllListeners();
            
            ExtendedOnDisable();
        }

        private void OnEnable()
        {
            if (TryGetComponent(out Animator anim))
            {
                _animator = anim;
                AssignAnimations();
            }
            
            ExtendedOnEnable();
        }

        protected virtual void ExtendedOnEnable()
        {
            
        }
        
        protected virtual void ExtendedOnDisable()
        {
            
        }
        
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
