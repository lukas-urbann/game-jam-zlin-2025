using UnityEngine;
using GJ25.Interface;
using GJ25.Player;

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
            hitInteractable?.Interact(this.player);
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
            if (player.State == ObjectState.Moving) return;
            
            Ray ray = new(transform.position, direction);

            if (!Physics.Raycast(ray, out RaycastHit hit, detectRayDistance))
            {
                hitInteractable?.InteractHoverHide(this.player);
                hitInteractable = null;
                return;
            }

            if (hit.collider.TryGetComponent(out IInteractable interactable))
            {
                if (interactable != hitInteractable)
                {
                    hitInteractable?.InteractHoverHide(this.player);
                    hitInteractable = interactable;
                    hitInteractable?.InteractHoverShow(this.player);
                }
                else
                {
                    hitInteractable?.InteractHoverStay(this.player);
                }
            }
        }
    }
}

