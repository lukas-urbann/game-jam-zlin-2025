using UnityEngine;

public class RaycastCubeScanner : MonoBehaviour
{
    public float detectRayDistance = 1f;
    public Vector3 hitDir { get; private set; }

    private void Update()
    {
        if (CheckDirection(Vector3.forward, "Forward")) hitDir = Vector3.forward;
        if (CheckDirection(Vector3.back, "Back")) hitDir = Vector3.back;
        if (CheckDirection(Vector3.left, "Left")) hitDir = Vector3.left;
        if (CheckDirection(Vector3.right, "Right")) hitDir = Vector3.right;
    }

    private bool CheckDirection(Vector3 direction, string directionName)
    {
        Ray ray = new Ray(transform.position, direction);
        
        if (Physics.Raycast(ray, out RaycastHit hit, detectRayDistance))
        {
            Debug.Log($"{directionName},{hit.collider.name}");
            Debug.DrawRay(transform.position, direction * detectRayDistance, Color.red);
            return true;
        }
        return false;
    }
}