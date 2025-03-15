using System;
using UnityEngine;

namespace GJ25.Grid
{
    public class GridSnap : MonoBehaviour
    {
        private void OnEnable()
        {
            GridSystem.Instance.onGridSpawned.AddListener(SnapToNearestGridNode);
        }

        private void SnapToNearestGridNode()
        {
            GridSystem.Instance.onGridSpawned.RemoveListener(SnapToNearestGridNode);

            var node = GridSystem.Instance.GetNearestNode(transform.position);

            if (node.OccupyingObject != null)
            {
                Debug.LogWarning($"Noda na ({node.GridX},{node.GridY}) má více objektů.", this);
            }
            
            if (TryGetComponent(out GridObject gridObject))
            {
                gridObject.SetGridNode(node);
            }

            transform.position = node.WorldPosition;

            node.OccupyingObject = gameObject;

            Debug.Log($"Objekt '{gameObject.name}' se snapnul na ({node.GridX},{node.GridY})");
        }
    }
}