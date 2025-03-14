using UnityEngine;

namespace GJ25.Raycasts
{
    public class InteractionFront : MonoBehaviour
    {
        public float detectRayDistance = 1f;
        public Vector3 hitDir { get; private set; }

        private void Update()
        {
            if (CheckDirection(Vector3.forward)) hitDir = Vector3.forward;
        }

        private bool CheckDirection(Vector3 direction)
        {
            Ray ray = new Ray(transform.position, direction);
            Debug.DrawRay(transform.position, direction * detectRayDistance, Color.red);

            if (Physics.Raycast(ray, out RaycastHit hit, detectRayDistance))
            {
                Debug.DrawRay(transform.position, direction * detectRayDistance, Color.green);
                return true;
            }

            return false;
        }
    }
}

