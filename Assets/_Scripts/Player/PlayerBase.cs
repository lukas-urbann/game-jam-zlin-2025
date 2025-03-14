using UnityEngine;
using GJ25.Grid;
using GJ25.Player;

public class PlayerBase : MonoBehaviour
{
    public enum PlayerState
    {
        Idle,
        Moving
    }

    private PlayerState currentState = PlayerState.Idle;
    public GridNode currentNode;
    private GridNode targetNode;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotSpeed = 20f;
    private Quaternion targetRotation;
    private PlayerControls _controls;


    private void OnEnable()
    {
        _controls = GetComponent<PlayerControls>();
    }

    private void Update()
    {
        RotateToTarget();

        switch (currentState)
        {
            case PlayerState.Idle:
                CheckForMovementInput();
                break;

            case PlayerState.Moving:
                MoveToTargetNode();
                break;
        }
    }

    void CheckForMovementInput()
    {
        int dx = 0, dy = 0;

        if(Input.GetKeyDown(_controls.up)) dy = 1;
        if(Input.GetKeyDown(_controls.down)) dy = -1;
        if(Input.GetKeyDown(_controls.left)) dx = -1;
        if (Input.GetKeyDown(_controls.right)) dx = 1;

        if (dx != 0 || dy != 0)
        {
            int newX = currentNode.GridX + dx;
            int newY = currentNode.GridY + dy;

            // Check if valid move
            if (GridSystem.Instance.Grid[newX, newY].OccupyingObject == null)
            {
                targetNode = GridSystem.Instance.Grid[newX, newY];
                currentState = PlayerState.Moving;
                
                Vector3 direction = (targetNode.WorldPosition - transform.position).normalized;
                targetRotation = Quaternion.LookRotation(direction);

                // Update grid occupancy
                GridSystem.Instance.Grid[currentNode.GridX, currentNode.GridY].OccupyingObject = null;
                GridSystem.Instance.Grid[targetNode.GridX, targetNode.GridY].OccupyingObject = gameObject;
            }
        }
    }

    private void MoveToTargetNode()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetNode.WorldPosition,
            moveSpeed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, targetNode.WorldPosition) < 0.01f)
        {
            transform.position = targetNode.WorldPosition;
            currentNode = targetNode;
            currentState = PlayerState.Idle;
        }
    }
    
    private void RotateToTarget()
    {
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            targetRotation,
            rotSpeed * Time.deltaTime
        );
    }
}
