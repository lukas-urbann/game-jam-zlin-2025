using GJ25.Grid;
using GJ25.Player;
using UnityEngine;

namespace GJ25.Interactables
{
    public class Chair : InteractableObjectBase
    {
        [SerializeField] private float moveSpeed = 5f;
        private Quaternion _targetRotation;
        private GridNode _targetNode;
        private ObjectState _currentState = ObjectState.Idle;
        public ObjectState State { get { return _currentState; } }
        public GridObject GridObject;
        
        public override void ExtendedInteraction(PlayerBase player)
        {
            if (player.dx != 0 || player.dy != 0)
            {
                int newX = GridObject.GetGridNode().GridX + player.dx;
                int newY = GridObject.GetGridNode().GridY + player.dy;

                _targetNode = GridSystem.Instance.Grid[newX, newY];
                Vector3 direction = (_targetNode.WorldPosition - transform.position).normalized;
                _targetRotation = Quaternion.LookRotation(direction);
                
                // Check if valid move
                if (GridSystem.Instance.Grid[newX, newY].OccupyingObject != null) return;
                _currentState = ObjectState.Moving;
                    
                // Update grid occupancy
                GridSystem.Instance.Grid[GridObject.GetGridNode().GridX, GridObject.GetGridNode().GridY].OccupyingObject = null;
                GridSystem.Instance.Grid[_targetNode.GridX, _targetNode.GridY].OccupyingObject = gameObject;
            }
        }

        private void MoveToTargetNode()
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                _targetNode.WorldPosition,
                moveSpeed * Time.deltaTime
            );

            if (Vector3.Distance(transform.position, _targetNode.WorldPosition) < 0.01f)
            {
                transform.position = _targetNode.WorldPosition;
                GridObject.SetGridNode(_targetNode);
                _currentState = ObjectState.Idle;
            }
        }
        
        private void RotateToTarget()
        {
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                _targetRotation,
                moveSpeed * Time.deltaTime
            );
        }
        
        private void FixedUpdate()
        {
            RotateToTarget();
        }
        
        private void CheckStates()
        {
            switch (_currentState)
            {
                case ObjectState.Moving:
                    MoveToTargetNode();
                    break;
            }
        }
        
        public void Update()
        {
            CheckStates();
        }
    }
}
