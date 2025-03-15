using GJ25.Grid;
using UnityEngine;

namespace GJ25.Systems
{
    public class SpawnSystem : MonoBehaviour
    {
        public GameObject wall;
        public GameObject redPlayer;
        public GameObject bluePlayer;

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
                    if(node.OccupyingObject.TryGetComponent(out GridObject go)) go.SetGridNode(node);
                }

                //temp player spawn
                if (node.GridX == 1 && node.GridY == 1)
                {
                    node.OccupyingObject = Instantiate(redPlayer, node.WorldPosition, Quaternion.identity);

                    if (node.OccupyingObject.TryGetComponent(out GridObject goa)) goa.SetGridNode(node);
                    if (node.OccupyingObject.TryGetComponent(out GridObject go)) go.SetGridNode(node);
                }

                if (node.GridX == GridSystem.Instance.GridXLength-1 && node.GridY == GridSystem.Instance.GridZLength-1)
                {
                    node.OccupyingObject = Instantiate(bluePlayer, node.WorldPosition, Quaternion.identity);
                    if (node.OccupyingObject.TryGetComponent(out GridObject goa)) goa.SetGridNode(node);
                    if (node.OccupyingObject.TryGetComponent(out GridObject go)) go.SetGridNode(node);
                }
            }
        }
    }
}