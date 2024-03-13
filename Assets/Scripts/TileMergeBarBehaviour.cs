using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMergeBarBehaviour : MonoBehaviour
{
    private const int TILE_MERGE_BAR_LENGTH = 7;
    private const int TILE_MERGE_LENGTH = 3;

    [SerializeField] private GameObject _tileMerge;

    private List<int> _tiles;

    public void GenerateTileMergeBar()
    {
        DestroyChildren();

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

    private IEnumerator MergeTile(int id)
    {
        int index = _tiles.IndexOf(id);
        int count = _tiles.FindAll(tileId => tileId == id).Count;

        if (count < TILE_MERGE_LENGTH) yield break;

        yield return new WaitForSeconds(0.2f);

        _tiles.RemoveAll(tileId => tileId == id);

        for(int i = 0; i < TILE_MERGE_LENGTH; i++)
        {
            Transform tileTransform = transform.GetChild(index + i);
            TileBehaviour tileBehaviour = tileTransform.GetComponentInChildren<TileBehaviour>();
            tileBehaviour.ClearData();
        }

        yield return new WaitForSeconds(0.3f);

        for (int i = 0; i < TILE_MERGE_LENGTH; i++)
        {
            Transform tileTransform = transform.GetChild(index);

            tileTransform.SetAsLastSibling();
        }
    }

    public void AddToTileList(TileSetting settings)
    {
        if (_tiles.Count >= TILE_MERGE_BAR_LENGTH) 
        { 
            GamePlayController.Instance.CurrentState = GamePlayController.GamePlayState.lose;
            return;
        }

        int index = GetPositionIndex(settings.Id);
        _tiles.InsertRange(index, new List<int> { settings.Id });

        Transform tileTransform = transform.GetChild(_tiles.Count - 1);
        TileBehaviour tileBehaviour = tileTransform.GetComponentInChildren<TileBehaviour>();

        tileBehaviour.SetData(settings);
        tileTransform.SetSiblingIndex(index);

        StartCoroutine(MergeTile(settings.Id));
    }

    private void DestroyChildren()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
