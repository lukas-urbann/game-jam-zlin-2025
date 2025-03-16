using UnityEngine;

namespace GJ25.Systems
{
    public class CameraLookAt : MonoBehaviour
    {
        public Transform target;
        public float smoothTime = 5;

        void LateUpdate()
        {
            if (target != null)
            {
                Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * smoothTime);
            }
        }
    }
}
