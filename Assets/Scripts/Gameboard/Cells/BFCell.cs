using Characters;
using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Gameboard
{
    public class BFCell : IEquatable<BFCell>
    {
        private readonly Vector3Int gridPosition;
        private GridElement content;

        public Vector3Int GridPosition => gridPosition;
        public GridElement Content => content;
        public bool IsContentFilled => content != null;

        public BFCell(Vector3Int gridPosition)
        {
            this.gridPosition = gridPosition;
        }

        public void SetContent(GridElement content)
        {
            this.content = content;
        }

        public bool Equals(BFCell other)
        {
            if (other == null) return false;

            return other.gridPosition == gridPosition;
        }
    }
}