using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GJ25.Grid
{
    public class GridSystem : MonoBehaviour
    {
        private GridNode[,] gameGrid;
        private Vector3 gridOrigin = Vector3.zero;

        public GridNode[,] Grid => gameGrid;
        public int GridXLength => gridWidth - 1;
        public int GridZLength => gridHeight - 1;

        [SerializeField] private int gridWidth = 17;
        [SerializeField] private int gridHeight = 10;
        [SerializeField] private float nodeDistance = 1;

        public UnityEvent onGridSpawned;

        #region Singleton
        public static GridSystem Instance
        {
            get
            {
                if (instance == null)
                    instance = FindObjectOfType(typeof(GridSystem)) as GridSystem;

                return instance;
            }
            set
            {
                instance = value;
            }
        }
        private static GridSystem instance;
        #endregion

        private void OnEnable()
        {
            InitializeGrid(this.gridWidth, this.gridHeight, this.nodeDistance);
        }

        private void InitializeGrid(int width, int height, float nodeSize)
        {
            gameGrid = new GridNode[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < height; z++)
                {
                    Vector3 worldPosition = new(x * nodeSize, 0, z * nodeSize);
                    gameGrid[x, z] = new GridNode(worldPosition, x, z);
                }
            }

            StartCoroutine(DelayedInvoke());
        }

        private IEnumerator DelayedInvoke()
        {
            yield return new WaitForEndOfFrame();
            onGridSpawned?.Invoke();
        }

        public GridNode GetNearestNode(Vector3 worldPosition)
        {
            int x = Mathf.RoundToInt((worldPosition.x - gridOrigin.x) / nodeDistance);
            int y = Mathf.RoundToInt((worldPosition.z - gridOrigin.z) / nodeDistance);

            x = Mathf.Clamp(x, 0, gridWidth - 1);
            y = Mathf.Clamp(y, 0, gridHeight - 1);

            return gameGrid[x, y];
        }

        public List<GridNode> GetAllBorderNodes()
        {
            List<GridNode> borderNodes = new List<GridNode>();
        
            // horni a dolni
            for (int x = 0; x < gridWidth; x++)
            {
                borderNodes.Add(gameGrid[x, 0]);
                borderNodes.Add(gameGrid[x, gridHeight - 1]);
            }
        
            // leva a prava
            for (int y = 1; y < gridHeight - 1; y++)
            {
                borderNodes.Add(gameGrid[0, y]);
                borderNodes.Add(gameGrid[gridWidth - 1, y]);
            }
        
            return borderNodes;
        }
    }
}