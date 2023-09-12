using UnityEngine.Tilemaps;

namespace Gameboard
{
    public class SelectorHandler
    {
        private readonly Tilemap tilemap;
        private readonly TileBase selectTile;
        private readonly TileBase unselectTile;

        private BFCell selectionCell;

        public SelectorHandler(Tilemap tilemap, TileBase selectTile, TileBase unselectTile)
        {
            this.tilemap = tilemap;
            this.selectTile = selectTile;
            this.unselectTile = unselectTile;
        }

        public void UpdateTile(BFCell cell)
        {
            if (cell.Equals(selectionCell)) return;

            if (selectionCell != null) ClearTile(selectionCell);

            selectionCell = cell;

            SetTile(selectionCell);
        }

        private void ClearTile(BFCell cell)
        {
            tilemap.SetTile(cell.GridPosition, unselectTile);
        }

        private void SetTile(BFCell cell)
        {
            tilemap.SetTile(cell.GridPosition, selectTile);
        }
    }
}