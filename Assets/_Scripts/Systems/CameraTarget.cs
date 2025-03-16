using UnityEngine;

namespace GJ25.Systems
{
    public class CameraTarget : MonoBehaviour
    {
        public Transform playerRed;
        public Transform playerBlue;
        [Range(0f, 1f)] public float t = 0.5f;

        void Update()
        {
            if (playerRed != null && playerBlue != null)
            {
                transform.position = Vector3.Lerp(playerRed.position, playerBlue.position, t);
            }
        }
    }
}
