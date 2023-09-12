using System;
using UnityEngine;

namespace Gameboard
{
    public class BFCell : IEquatable<BFCell>
    {
        private readonly Vector3Int gridPosition;
        private GameObject content;

        public Vector3Int GridPosition => gridPosition;
        public GameObject Content => content;
        public bool IsContentFilled => content != null;

        public BFCell(Vector3Int gridPosition)
        {
            this.gridPosition = gridPosition;
        }

        public void SetContent(GameObject content)
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