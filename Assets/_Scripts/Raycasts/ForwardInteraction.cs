using UnityEngine;
using GJ25.Interface;

namespace GJ25.Raycasts
{
    public class ForwardInteraction : MonoBehaviour
    {
        private PlayerBase player;
        private Vector3 playerForward;

        public float detectRayDistance = 1f;

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
            if (CheckDirection(playerForward, out GameObject hitGo))
            {
                Debug.Log(hitGo.name);
            }
        }

        private bool CheckDirection(Vector3 direction, out GameObject hitGo)
        {
            hitGo = null;
            if (player.State == PlayerBase.PlayerState.Moving) return false;

            Ray ray = new(transform.position, direction);
            Debug.DrawRay(transform.position, direction * detectRayDistance, Color.red);

            if (Physics.Raycast(ray, out RaycastHit hit, detectRayDistance))
            {
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

