using UnityEngine;

namespace GJ25.Grid
{
    public class GridNode : MonoBehaviour
    {
        public Vector3 WorldPosition { get; private set; }
        public GameObject OccupyingObject { get; set; }

        public int GridX { get; private set; }
        public int GridY { get; private set; }

        public GridNode(Vector3 worldPos, int gridX, int gridY)
        {
            WorldPosition = worldPos;
            GridX = gridX;
            GridY = gridY;
            OccupyingObject = null;
        }
    }
}