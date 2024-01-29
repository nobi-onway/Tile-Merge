using UnityEngine;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Level", menuName = "Level Settings")]
public class LevelSettings : ScriptableObject
{

    [Serializable]
    public class Tile
    {
        public TileSetting Setting;
        public int count;
    }  
    
    [SerializeField]
    private string _name;
    public string Name { get { return _name; } }
    public int Id => _name.GetHashCode();

    public List<Vector2> TilePositions
    {
        get
        {
            List<Vector2> tilePositions = new List<Vector2>();
            int childCount = Board.transform.childCount;

            for(int i = 0; i < childCount; i++)
            {
                Vector2 position = Board.transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition;
                tilePositions.Add(position);
            }

            return tilePositions;
        }
    }
    public List<Tile> Tiles;

    public GameObject Board;
}
