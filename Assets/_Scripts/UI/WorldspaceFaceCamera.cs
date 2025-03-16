using UnityEngine;

namespace GJ25.UI
{
    public class WorldspaceFaceCamera : MonoBehaviour
    {
        private Camera mainCamera;

        void Start()
        {
            mainCamera = Camera.main;
        }

        void LateUpdate()
        {
            if (mainCamera != null)
            {
                transform.LookAt(mainCamera.transform, Vector3.down);
            }
        }
    }
}

