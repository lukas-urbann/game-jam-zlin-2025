using UnityEngine;
using GJ25.Grid;

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

    private void Update()
    {
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

        if (Input.GetKeyDown(KeyCode.W)) dy = 1;
        else if (Input.GetKeyDown(KeyCode.S)) dy = -1;
        else if (Input.GetKeyDown(KeyCode.A)) dx = -1;
        else if (Input.GetKeyDown(KeyCode.D)) dx = 1;

        if (dx != 0 || dy != 0)
        {
            int newX = currentNode.GridX + dx;
            int newY = currentNode.GridY + dy;

            // Check if valid move
            if (GridSystem.Instance.Grid[newX, newY].OccupyingObject == null)
            {
                targetNode = GridSystem.Instance.Grid[newX, newY];
                currentState = PlayerState.Moving;

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
}
