using UnityEngine;

namespace Characters
{
    public class GridElement
    {
        private readonly Vector3Int gridPosition;

        public Vector3Int GridPosition => gridPosition;

        protected GridElement(Vector3Int gridPosition)
        {
            this.gridPosition = gridPosition;
        }
    }
}