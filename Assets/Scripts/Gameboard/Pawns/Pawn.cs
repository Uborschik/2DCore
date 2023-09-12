using UnityEngine;

namespace Characters
{
    public abstract class Pawn : GridElement
    {
        protected Pawn(Vector3Int gridPosition) : base(gridPosition)
        {
        }
    }
}