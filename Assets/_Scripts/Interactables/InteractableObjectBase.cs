using System;
using System.Collections;
using GJ25.Interface;
using GJ25.Player;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GJ25.Interactables
{
    public abstract class InteractableObjectBase : MonoBehaviour, IInteractable
    {
        //PlayerBase otherPlayer = PlayerQuery.players.FirstOrDefault(p => p != playerBase);
        //if(otherPlayer != null) Debug.Log($"Applying debuff from {playerBase.name} to: {otherPlayer.name}");

        [SerializeField] private GameObject modelObject;
        [SerializeField] private GameObject loadBar;
        [SerializeField] private Image loadBarFill;
        [SerializeField] private float cooldown = 10;
        protected bool CanInteract = true;

        protected void StartCooldown()
        {
            StartCoroutine(WaitForCooldown());
            StartCoroutine(WaitForLoadBar());
        }

        private IEnumerator WaitForCooldown()
        {
            DisableInteractable();
            yield return new WaitForSeconds(cooldown);
            EnableInteractable();
        }

        private IEnumerator WaitForLoadBar()
        {
            float startFill = 0;
            if (loadBarFill)
            {
                startFill = loadBarFill.fillAmount;
            }
            float elapsed = 0f;

            while (elapsed < cooldown)
            {
                elapsed += Time.deltaTime;
                if (loadBarFill) loadBarFill.fillAmount = Mathf.Lerp(startFill, 1, elapsed / cooldown);
                yield return null;
            }
        }

        protected void EnableInteractable()
        {
            CanInteract = true;
            if (loadBarFill) loadBarFill.fillAmount = 1;
            modelObject?.SetActive(true);
            loadBar?.SetActive(false);
            DisableHoverAnimation(null);
        }

        protected void DisableInteractable()
        {
            CanInteract = false;
            if (loadBarFill) loadBarFill.fillAmount = 0;
            modelObject?.SetActive(false);
            loadBar?.SetActive(true);
        }
        
        [SerializeField] private Animator _animator;

        private void EnableHoverAnimation(object _) => _animator.SetBool("hover", true);
            
        private void DisableHoverAnimation(object _) => _animator.SetBool("hover", false);

        private void CheckHoverAnimation(object _)
        {
            if (!CanInteract)
            {
                _animator.SetBool("hover", false);
            }
            else
            {
                _animator.SetBool("hover", true);
            }
        }
        
        private void AssignAnimations()
        {
            onInteractHoverShow?.AddListener(EnableHoverAnimation);
            onInteractHoverHide?.AddListener(DisableHoverAnimation);
            onInteractHoverStay?.AddListener(CheckHoverAnimation);
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

        public void Interaction(PlayerBase player)
        {
            if (!CanInteract) return;
            if(!ExtendedCondition(player)) return;
            StartCooldown();
            ExtendedInteraction(player);
        }

        public abstract void ExtendedInteraction(PlayerBase player);
        public abstract bool ExtendedCondition(PlayerBase player);

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
