using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    //GridSystem.Instance.Grid.GetLength(0); - x
    //GridSystem.Instance.Grid.GetLength(1); - z
        
    public GameObject wall;

    private void OnEnable()
    {
        GridSystem.Instance.onGridSpawned.AddListener(SpawnWalls);
    }

    private void OnDisable()
    {
        GridSystem.Instance.onGridSpawned.RemoveListener(SpawnWalls);
    }

    private void Start()
    {
        SpawnWalls();
    }

    private void SpawnWalls()
    {
        foreach (var node in GridSystem.Instance.Grid)
        {
            if (node.GridX == 0 || node.GridY == 0 || node.GridX == GridSystem.Instance.GridXLength || node.GridY == GridSystem.Instance.GridZLength)
            {
                Instantiate(wall, node.WorldPosition, Quaternion.identity);
            }
        }
    }
}
