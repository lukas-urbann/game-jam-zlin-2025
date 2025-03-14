using UnityEngine;

public abstract class GridObject : Interactable
{
    [SerializeField] protected Vector2Int gridPos;
    public Vector2Int GridPos => gridPos;
    
}