using System;
using System.Collections.Generic;
using UnityEngine;
using static LevelSettings;

public class TileBoardBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _tile;

    [SerializeField]
    private LevelSettings levelSettings;

    private Queue<Tile> _tileQueue;
    private List<Vector2> _tilePositions;

    public event Action<TileSetting> OnSelectedTile;

    private void Start()
    {
        GenerateBoard();
    }

    private void SpawnTile(Vector2 anchoredPosition, TileSetting settings)
    {
        GameObject tileClone = Instantiate(_tile, transform);

        TileBehaviour tileCloneBehavior = tileClone.GetComponent<TileBehaviour>();

        tileClone.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
        tileCloneBehavior.SetData(settings);
        tileCloneBehavior.OnPointerDownHandler += () => { OnSelectedTile?.Invoke(settings); Destroy(tileClone); };
    }

    private void GenerateBoard()
    {
        GenerateTileQueue();
        GenerateTilePostions();

        foreach (Vector2 position in _tilePositions)
        {
            SpawnTile(position, _tileQueue.Dequeue().Setting);
        }
    }

    private void GenerateTileQueue()
    {
        if (_tileQueue == null) _tileQueue = new Queue<Tile>();

        foreach(Tile tile in levelSettings.Tiles)
        {
            for(int i = 0; i < tile.count; i++)
            {
                _tileQueue.Enqueue(tile);
            }
        }
    }

    private void GenerateTilePostions()
    {
        _tilePositions = levelSettings.TilePositions;

        SuffleTilePositions(_tilePositions);
    }

    private void SuffleTilePositions(List<Vector2> tilePositions)
    {
        int n = tilePositions.Count;

        while (n > 1)
        {
            n--;
            int k = UnityEngine.Random.Range(0, n + 1);
            Vector2 value = tilePositions[k];
            tilePositions[k] = tilePositions[n];
            tilePositions[n] = value;
        }
    }
}
