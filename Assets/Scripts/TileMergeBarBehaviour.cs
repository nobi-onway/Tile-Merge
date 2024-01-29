using System;
using System.Collections.Generic;
using UnityEngine;

public class TileMergeBarBehaviour : MonoBehaviour
{
    private const int TILE_MERGE_BAR_LENGTH = 7;
    private const int TILE_MERGE_LENGTH = 3;

    [SerializeField] private GameObject _tileMerge;

    private List<int> _tiles;

    private void Start()
    {
        GenerateTileMergeBar();
    }

    private void GenerateTileMergeBar()
    {
        _tiles = new List<int>();

        for (int i = 0; i < TILE_MERGE_BAR_LENGTH; i++)
        {
            Instantiate(_tileMerge, transform);
        }
    }

    private int GetPositionIndex(int id)
    {
        int index = _tiles.FindLastIndex(tileId => tileId == id) + 1;

        return index == 0 ? _tiles.Count : index;
    }

    private void MergeTile(int id)
    {
        int index = _tiles.IndexOf(id);
        int count = _tiles.FindAll(tileId => tileId == id).Count;

        if (count < TILE_MERGE_LENGTH) return;

        _tiles.RemoveAll(tileId => tileId == id);

        for(int i = 0; i < TILE_MERGE_LENGTH; i++)
        {
            Transform tileTransform = transform.GetChild(index);
            tileTransform.SetAsLastSibling();

            TileBehaviour tileBehaviour = tileTransform.GetComponentInChildren<TileBehaviour>();
            tileBehaviour.ClearData();
        }
    }

    public void AddToTileList(TileSetting settings)
    {
        int index = GetPositionIndex(settings.Id);
        _tiles.Add(settings.Id);

        Transform tileTransform = transform.GetChild(_tiles.Count - 1);
        TileBehaviour tileBehaviour = tileTransform.GetComponentInChildren<TileBehaviour>();

        tileBehaviour.SetData(settings);
        tileTransform.SetSiblingIndex(index);

        MergeTile(settings.Id);
    }
}
