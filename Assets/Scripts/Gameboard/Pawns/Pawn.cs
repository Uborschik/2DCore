using System.Collections;
using System.Collections.Generic;
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