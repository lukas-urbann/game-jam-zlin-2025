using System.Collections.Generic;
using GJ25.Debuff;
using UnityEngine;
using GJ25.Grid;
using UnityEngine.Events;

namespace GJ25.Player
{
    public enum ObjectState
    {
        Idle,
        Moving
    }
    
    public class PlayerBase : MonoBehaviour
    {
        private ObjectState _currentState = ObjectState.Idle;
        public ObjectState State { get { return _currentState; } }
        public float InitialSpeed => _initialSpeed;
        
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float rotSpeed = 20f;
        
        public PlayerComputer computer;
        
        public int dx = 0, dy = 0;
        
        private List<EffectBase> activeEffects = new List<EffectBase>();
        
        #region Private
        private GridNode _targetNode;
        private Quaternion _targetRotation;
        private PlayerControls _controls;
        private float _initialSpeed;
        private GridObject _currentNode;
        private Animator _animator;
        #endregion
        
        public UnityEvent onInteractPerformed = new();
        
        private void OnEnable()
        {
            PlayerQuery.players.Add(this);
            
            if (TryGetComponent(out GridObject go)) _currentNode = go;
            if (TryGetComponent(out PlayerControls ct)) _controls = ct;
            if (TryGetComponent(out Animator anim)) _animator = anim;
        }
        
        private void Start()
        {
            _initialSpeed = moveSpeed;
        }

        private void Update()
        {
            CheckStates();
            CheckEffects();
        }

        private void CheckEffects()
        {
            for (int i = activeEffects.Count - 1; i >= 0; i--)
            {
                if (activeEffects[i].UpdateDebuff(Time.deltaTime))
                {
                    activeEffects.RemoveAt(i);
                }
            }
        }

        private void CheckStates()
        {
            switch (_currentState)
            {
                case ObjectState.Idle:
                    _animator.SetBool("move", false);
                    CheckForMovementInput();
                    break;

                case ObjectState.Moving:
                    _animator.SetBool("move", true);
                    MoveToTargetNode();
                    break;
            }
        }
        
        public void AddDebuff(EffectBase effect)
        {
            effect.ApplyEffect();
            activeEffects.Add(effect);
        }

        private void FixedUpdate()
        {
            RotateToTarget();
        }
            
        private void CheckForMovementInput()
        {
            dx = 0;
            dy = 0;

            if(Input.GetKey(_controls.up)) dy = 1;
            else if(Input.GetKey(_controls.down)) dy = -1;
            else if(Input.GetKey(_controls.left)) dx = -1;
            else if (Input.GetKey(_controls.right)) dx = 1;

            if (Input.GetKeyDown(_controls.interact)) onInteractPerformed?.Invoke();
            
            if (dx != 0 || dy != 0)
            {
                int newX = _currentNode.GetGridNode().GridX + dx;
                int newY = _currentNode.GetGridNode().GridY + dy;

                _targetNode = GridSystem.Instance.Grid[newX, newY];
                Vector3 direction = (_targetNode.WorldPosition - transform.position).normalized;
                _targetRotation = Quaternion.LookRotation(direction);
                
                // Check if valid move
                if (GridSystem.Instance.Grid[newX, newY].OccupyingObject != null) return;
                _currentState = ObjectState.Moving;
                    
                // Update grid occupancy
                GridSystem.Instance.Grid[_currentNode.GetGridNode().GridX, _currentNode.GetGridNode().GridY].OccupyingObject = null;
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
                _currentNode.SetGridNode(_targetNode);
                _currentState = ObjectState.Idle;
            }
        }
        
        private void RotateToTarget()
        {
            transform.rotation = Quaternion.Lerp(
                transform.rotation,
                _targetRotation,
                rotSpeed * Time.deltaTime
            );
        }

        public void SetSpeed(float multiplier)
        {
            moveSpeed = _initialSpeed * multiplier;
        }
    }
}