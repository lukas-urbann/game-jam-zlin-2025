using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public GameObject wall;
    public GameObject player;

    private void OnEnable()
    {
        GridSystem.Instance.onGridSpawned.AddListener(SpawnWalls);
    }

    private void OnDisable()
    {
        GridSystem.Instance.onGridSpawned.RemoveListener(SpawnWalls);
    }

    private void SpawnWalls()
    {
        foreach (var node in GridSystem.Instance.Grid)
        {
            if (node.GridX == 0 ||
                node.GridY == 0 ||
                node.GridX == GridSystem.Instance.GridXLength ||
                node.GridY == GridSystem.Instance.GridZLength)
            {
                node.OccupyingObject = Instantiate(wall, node.WorldPosition, Quaternion.identity);
            }

            if (node.GridX == 1 && node.GridY == 1)
            {
                node.OccupyingObject = Instantiate(player, node.WorldPosition, Quaternion.identity);
                node.OccupyingObject.GetComponent<PlayerBase>().currentNode = node;
            }
        }
    }
}
