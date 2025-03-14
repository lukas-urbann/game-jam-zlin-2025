using UnityEngine;
using GJ25.Interface;

namespace GJ25.Grid
{
    public abstract class GridObject : MonoBehaviour, IInteractable
    {
        [SerializeField] protected Vector2Int gridPos;
        public Vector2Int GridPos => gridPos;

        public void Interact()
        {
            throw new System.NotImplementedException();
        }
    }
}
