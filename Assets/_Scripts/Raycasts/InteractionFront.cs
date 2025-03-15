using UnityEngine;
using GJ25.Interface;
namespace GJ25.Raycasts
{
    public class InteractionFront : MonoBehaviour
    {
        public float detectRayDistance = 1f;
        public Vector3 hitDir { get; private set; }
        private PlayerBase player;

        // uh oh... stinky...
        private void Start()
        {
            if (player == null)
                player = GetComponent<PlayerBase>();
        }

        private void Update()
        {
            Vector3 playerForward = player.transform.forward;
            if (CheckDirection(playerForward))
            {
                hitDir = playerForward;
            }
        }

        private bool CheckDirection(Vector3 direction)
        {
            Ray ray = new Ray(transform.position, direction);
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

