using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMergeBarBehaviour : MonoBehaviour
{
    private const int TILE_MERGE_BAR_LENGTH = 7;

    [SerializeField] private GameObject _tileMerge;

    private void Start()
    {
        GenerateTileMergeBar();
    }

    private void GenerateTileMergeBar()
    {
        for (int i = 0; i < TILE_MERGE_BAR_LENGTH; i++)
        {
            Instantiate(_tileMerge, transform);
        }
    }
}
