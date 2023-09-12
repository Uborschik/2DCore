using UnityEngine;
using UnityEngine.Tilemaps;

namespace Gameboard
{
    public class InputReader : IInputReader<BFCell>
    {
        private readonly Tilemap tilemap;
        private readonly TileBase[] tiles;

        private Vector3Int origin;
        private Vector3Int size;

        private Vector3 contentOffset;

        public InputReader(Tilemap tilemap)
        {
            this.tilemap = tilemap;

            tilemap.CompressBounds();

            var bounds = tilemap.cellBounds;

            tiles = tilemap.GetTilesBlock(bounds);

            origin = bounds.position;
            size = bounds.size;

            var cellSize = tilemap.cellSize;
            contentOffset = new Vector3(cellSize.x / 2, cellSize.y / 2);
        }

        public BFCell[,] ReadInputToGrid()
        {
            var grid = new BFCell[size.x, size.y];

            for (int y = 0; y < size.y; y++)
            {
                for (int x = 0; x < size.x; x++)
                {
                    var index = y * size.x + x;

                    var position = new Vector3Int(x + origin.x, y + origin.y);

                    grid[x, y] = new BFCell(position);
                }
            }

            return grid;
        }
    }
}