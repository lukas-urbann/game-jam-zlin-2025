using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GJ25.Grid
{
    public class GridSystem : MonoBehaviour
    {
        public static GridSystem Instance;
        [SerializeField] private GridNode[,] gameGrid;
        public GridNode[,] Grid => gameGrid;
        public int GridXLength => Grid.GetLength(0) - 1;
        public int GridZLength => Grid.GetLength(1) - 1;

        [SerializeField] private List<GameObject> gridObjects = new();
        [SerializeField] private GameObject gridVisualisation;

        [SerializeField] private int gridWidth = 16;
        [SerializeField] private int gridHeight = 10;
        [SerializeField] private float nodeDistance = 1;

        public UnityEvent onGridSpawned;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        private void Start()
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
                    gridObjects.Add(Instantiate(gridVisualisation, worldPosition, Quaternion.identity));
                }
            }

            onGridSpawned?.Invoke();
        }
    }
}