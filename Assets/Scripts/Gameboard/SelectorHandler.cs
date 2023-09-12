using UnityEngine.Tilemaps;
using UnityEngine.WSA;

namespace Gameboard
{
    public class SelectorHandler
    {
        private readonly Tilemap tilemap;

        private BFCell selectionCell;

        public SelectorHandler(Tilemap tilemap)
        {
            this.tilemap = tilemap;
        }

        public void UpdateTile(BFCell cell, TileBase tile)
        {
            if (cell.Equals(selectionCell)) return;
            else
            {
                if(selectionCell != null)
                {
                    ClearTile(selectionCell);
                }

                selectionCell = cell;

                SetTile(cell, tile);
            }

        }

        private void ClearTile(BFCell cell)
        {
            tilemap.SetTile(cell.GridPosition, null);
        }

        private void SetTile(BFCell cell, TileBase tile)
        {
            tilemap.SetTile(cell.GridPosition, tile);
        }
    }
}