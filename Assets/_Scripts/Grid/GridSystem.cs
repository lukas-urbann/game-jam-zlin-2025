using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GJ25.Grid
{
    public class GridSystem : MonoBehaviour
    {
        public static GridSystem Instance;
        private GridNode[,] gameGrid;
        public GridNode[,] Grid => gameGrid;
        public int GridXLength => gridWidth - 1;
        public int GridZLength => gridHeight - 1;

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
                }
            }
            onGridSpawned?.Invoke();
        }

        private void ShuffleList<T>(List<T> list)
        {
            System.Random random = new();
            int n = list.Count;

            for (int i = n - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                (list[j], list[i]) = (list[i], list[j]); // absolutnì šílená syntaxe, co to je pro kristovy rány
            }
        }

        private void PlaceObjectAtNode(GridNode node, GameObject go)
        {
            GameObject obj = Instantiate(go, node.WorldPosition, Quaternion.identity);
            obj.name = $"{go.name}_X{node.GridX}_Y{node.GridY}";
            node.OccupyingObject = obj;
        }

        private List<GridNode> GetAllBorderNodes()
        {
            List<GridNode> borderNodes = new();

            //top, bottom
            for (int x = 0; x < gridWidth; x++)
            {
                borderNodes.Add(gameGrid[x, 0]);
                borderNodes.Add(gameGrid[x, gridHeight - 1]);
            }

            //left, right
            for (int y = 1; y < gridHeight - 1; y++)
            {
                borderNodes.Add(gameGrid[0, y]);
                borderNodes.Add(gameGrid[gridWidth - 1, y]);
            }

            return borderNodes;
        }
    }
}