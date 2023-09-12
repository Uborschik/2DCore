using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameboard
{
    public class PawnSpawner : MonoBehaviour
    {
        [SerializeField] private GameboardController gameboard;
        [SerializeField] private GameObject pawnPrefab;
        [SerializeField] private List<GameObject> pawns;
        [SerializeField] private int spawnedPawnCount;

        private List<Vector3Int> alliesPawnsPositions = new();
        private List<Vector3Int> enemiesPawnsPositions = new();


        private void Start()
        {
            var maxX = gameboard.Grid.GetLength(0);
            var maxY = gameboard.Grid.GetLength(1);
            while (alliesPawnsPositions.Count < spawnedPawnCount)
            {
                var x = 0;
                var y = Random.Range(0, maxY);
                var position = new Vector3Int(x, y);
                if (alliesPawnsPositions.Contains(position)) continue;
                alliesPawnsPositions.Add(position);
            }

            foreach (var pawn in alliesPawnsPositions)
            {
                var cell = gameboard.Grid[pawn.x, pawn.y];
                Spawn(cell);
            }
        }

        private void Spawn(BFCell cell)
        {
            var instance = Instantiate(pawnPrefab);
            var position = cell.GridPosition +
                           new Vector3(0.5f, 0.5f);
            instance.transform.position = position;
        }
    }
}