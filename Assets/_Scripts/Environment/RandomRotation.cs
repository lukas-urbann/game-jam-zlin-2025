using UnityEngine;

namespace GJ25.Environment
{
    public class RandomRotation : MonoBehaviour
    {
        [SerializeField] private bool rotateX = false;
        [SerializeField] private bool rotateY = false;
        [SerializeField] private bool rotateZ = false;

        private void OnEnable()
        {
            transform.Rotate(new Vector3(
                rotateX ? Random.Range(0, 4) * 90 : 0f,
                rotateY ? Random.Range(0, 4) * 90 : 0f,
                rotateZ ? Random.Range(0, 4) * 90 : 0f
                ), Space.World);
        }
    }
}
