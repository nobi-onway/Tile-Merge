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
    private Queue<TileBehaviour> _disableTileQueue;
    private List<Vector2> _tilePositions;

    public event Action<TileSetting> OnSelectedTile;

    private void Start()
    {
        GenerateBoard();
    }

    private void SpawnTile(Vector2 anchoredPosition, TileSetting settings, bool enabled)
    {
        GameObject tileClone = Instantiate(_tile, transform);

        TileBehaviour tileCloneBehavior = tileClone.GetComponent<TileBehaviour>();

        tileClone.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;

        tileCloneBehavior.SetData(settings);

        if (!enabled)
        {
            tileCloneBehavior.Enabled = false;
            _disableTileQueue.Enqueue(tileCloneBehavior);
        }

        tileCloneBehavior.OnPointerDownHandler += () => { OnSelectedTile?.Invoke(settings); Destroy(tileClone); EnableTileInQueue(); };
    }

    private void EnableTileInQueue()
    {
       if (_disableTileQueue.Count <= 0) return;
       _disableTileQueue.Dequeue().Enabled = true;
    }

    private void GenerateBoard()
    {
        GenerateTileQueue();
        GenerateTilePostions();

        int positionCount = _tilePositions.Count;

        for (int i = 0; i < positionCount; i++)
        {
            SpawnTile(_tilePositions[i], _tileQueue.Dequeue().Setting, i < levelSettings.EnableTiles);
        }
    }

    private void GenerateTileQueue()
    {
        if (_tileQueue == null) _tileQueue = new Queue<Tile>();
        if (_disableTileQueue == null) _disableTileQueue = new Queue<TileBehaviour>();

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
