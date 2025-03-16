using UnityEngine;

namespace GJ25.Systems
{
    public class CameraLookAt : MonoBehaviour
    {
        public Transform pointA; // First object
        public Transform pointB; // Second object
        public float lerpFactor = 0.5f; // 0 = pointA, 1 = pointB
        public float followSpeed = 5f; // How fast the camera moves

        private Vector3 offset; // Initial offset from the lerp point

        void Start()
        {
            if (pointA != null && pointB != null)
            {
                // Set initial offset based on the first calculated midpoint
                Vector3 initialLerpPos = Vector3.Lerp(pointA.position, pointB.position, lerpFactor);
                offset = transform.position - initialLerpPos;
            }
        }

        void Update()
        {
            if (pointA != null && pointB != null)
            {
                // Calculate the current lerp position
                Vector3 lerpPosition = Vector3.Lerp(pointA.position, pointB.position, lerpFactor);

                // Move the camera while maintaining its offset
                Vector3 targetPosition = lerpPosition + offset;
                transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
            }
        }
    }
}
