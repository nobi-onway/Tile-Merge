using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBoardBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _tile;

    private void Start()
    {
        SpawnTile();
    }

    private void SpawnTile()
    {
        GameObject tileClone = Instantiate(_tile, transform);

        tileClone.GetComponent<RectTransform>().anchoredPosition = new Vector2(-500, 200);
    }
}
