using UnityEngine;
using GJ25.Interface;

namespace GJ25.Raycasts
{
    public class ForwardInteraction : MonoBehaviour
    {
        private PlayerBase player;
        
        public float detectRayDistance = 1f;
        public Vector3 hitDir { get; private set; }


        private void OnEnable()
        {
            if (TryGetComponent(out PlayerBase player)) this.player = player;
        }

        private void FixedUpdate()
        {
            Vector3 playerForward = player.transform.forward;
            if (CheckDirection(playerForward))
            {
                hitDir = playerForward;
            }
        }

        private bool CheckDirection(Vector3 direction)
        {
            Ray ray = new(transform.position, direction);
            Debug.DrawRay(transform.position, direction * detectRayDistance, Color.red);

            if (Physics.Raycast(ray, out RaycastHit hit, detectRayDistance))
            {
                if (player.State == PlayerBase.PlayerState.Moving) return false;

                if (hit.collider.TryGetComponent(out IInteractable interactable))
                {
                    Debug.DrawRay(transform.position, direction * detectRayDistance, Color.green);
                    return true;
                }
            }

            return false;
        }
    }
}

