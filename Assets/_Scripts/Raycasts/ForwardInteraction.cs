using UnityEngine;
using GJ25.Interface;

namespace GJ25.Raycasts
{
    public class ForwardInteraction : MonoBehaviour
    {
        private PlayerBase player;
        private Vector3 playerForward;

        public float detectRayDistance = 1f;

        private IInteractable hitInteractable;

        public void InteractPerformed()
        {
            hitInteractable?.Interact();
        }
        
        private void OnEnable()
        {
            if (TryGetComponent(out PlayerBase player)) this.player = player;
        }

        private void Update()
        {
            playerForward = player.transform.forward;
        }

        private void FixedUpdate()
        {
            CheckDirection(playerForward);
        }

        private void CheckDirection(Vector3 direction)
        {
            if (player.State == PlayerBase.PlayerState.Moving) return;
            
            Ray ray = new(transform.position, direction);

            if (!Physics.Raycast(ray, out RaycastHit hit, detectRayDistance))
            {
                hitInteractable?.InteractHoverHide();
                hitInteractable = null;
                return;
            }

            if (hit.collider.TryGetComponent(out IInteractable interactable))
            {
                if (interactable != hitInteractable)
                {
                    hitInteractable?.InteractHoverHide();
                    hitInteractable = interactable;
                    hitInteractable?.InteractHoverShow();
                }
                else
                {
                    hitInteractable?.InteractHoverStay();
                }
            }
        }
    }
}

