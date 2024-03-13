using UnityEngine;
using System;
using System.Collections.Generic;

public class LevelController : MonoBehaviour
{
    private const string CURRENT_LEVEL_KEY = "current_level";
    private static LevelController _instance;
    public static LevelController Instance => _instance;

    [SerializeField]
    private List<LevelSettings> _allLevelSettings;

    private int _currentLevel => PlayerPrefs.GetInt(CURRENT_LEVEL_KEY);

    public LevelSettings CurrentLevelSetting
    { 
       get => _allLevelSettings[_currentLevel];
    }

    public void LevelUp()
    {
        int nextLevel = _currentLevel >= _allLevelSettings.Count - 1 ? 0 : _currentLevel + 1;

        PlayerPrefs.SetInt(CURRENT_LEVEL_KEY, nextLevel);
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }
}
