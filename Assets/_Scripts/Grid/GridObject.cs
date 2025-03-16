using UnityEngine;

namespace GJ25.Grid
{
    public class GridObject : MonoBehaviour
    {
        private GridNode currentGridNode;

        public void SetGridNode(GridNode g) => currentGridNode = g;
        public GridNode GetGridNode() => currentGridNode;
    }
}
