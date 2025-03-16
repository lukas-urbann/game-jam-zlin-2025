using GJ25.Grid;
using UnityEngine;

namespace GJ25.Systems
{
    public class SpawnSystem : MonoBehaviour
    {
        public GameObject wallPrefab;

        private void OnEnable()
        {
            GridSystem.Instance.onGridSpawned.AddListener(SpawnWalls);
        }

        private void SpawnWalls()
        {
            GridSystem.Instance.onGridSpawned.RemoveListener(SpawnWalls);
            
            GridSystem.Instance.GetAllBorderNodes().ForEach(n =>
            {
                n.OccupyingObject = Instantiate(wallPrefab, n.WorldPosition, Quaternion.identity);
                
                if (n.OccupyingObject.TryGetComponent(out GridObject go))
                {
                    go.SetGridNode(n);
                }
            });
        }
    }
}