using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Tile", menuName = "Tile Setting"), Serializable]
public class TileSetting : ScriptableObject
{
    [SerializeField] 
    private string _name;
    public string Name { get { return _name; } }
    [SerializeField]
    private Sprite _sprite;
    public Sprite Sprite { get { return _sprite; } }

    public int Id => _name.GetHashCode();
}
