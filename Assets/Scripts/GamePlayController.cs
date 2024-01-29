using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    [SerializeField]
    private TileBoardBehaviour _tileBoardBehaviour;
    [SerializeField]
    private TileMergeBarBehaviour _tileMergeBarBehavior;

    private void Start()
    {
        _tileBoardBehaviour.OnSelectedTile += AddToTileBar;
    }

    private void AddToTileBar(TileSetting settings) => _tileMergeBarBehavior.AddToTileList(settings);
}
