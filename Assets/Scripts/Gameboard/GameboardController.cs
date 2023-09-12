using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

namespace Gameboard
{
    public class GameboardController : MonoBehaviour
    {
        [SerializeField] private Tilemap bfTilemap;
        [SerializeField] private Tilemap selectTilemap;
        [SerializeField] private TileBase selectedTile;
        [SerializeField] private TileBase unselectedTile;

        private Camera mainCamera;
        private BFCell[,] grid;
        public BFCell[,] Grid => grid;
        private SelectorHandler preview;

        private void Awake()
        {
            mainCamera = Camera.main;

            grid = new InputReader(bfTilemap).ReadInputToGrid();
            preview = new SelectorHandler(selectTilemap, selectedTile, unselectedTile);
        }

        private void Start()
        {
        }

        public void SelectCell(InputAction.CallbackContext context)
        {
            var screenPosition = Mouse.current.position.ReadValue();
            var origin = mainCamera.ScreenPointToRay(screenPosition);
            var hit = Physics2D.GetRayIntersection(origin);

            if (hit.collider)
            {
                if (context.performed)
                {
                    var cell = GetCell(hit.point);
                    preview.UpdateTile(cell);
                }
            }
        }

        #region Help Methods

        public BFCell GetCell(int x, int y)
        {
            if (IsValid(x, y))
            {
                return grid[x, y];
            }

            return null;
        }

        public BFCell GetCell(Vector3 position)
        {
            GetXY(position, out int x, out int y);

            return GetCell(x, y);
        }

        public Vector3Int GetCellPosition(Vector3 position)
        {
            return bfTilemap.WorldToCell(position);
        }

        private void GetXY(Vector3 position, out int x, out int y)
        {
            var cellPosition = GetCellPosition(position);

            x = cellPosition.x - bfTilemap.cellBounds.position.x;
            y = cellPosition.y - bfTilemap.cellBounds.position.y;
        }

        private bool IsValid(int x, int y)
        {
            return x >= 0 && y >= 0 && x < grid.GetLength(0) && y < grid.GetLength(1);
        }

        #endregion
    }
}