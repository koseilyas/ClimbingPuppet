using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : Singleton<PlayerDataManager>
{
    private PlayerData _playerData;
    private string _playerPrefsKey = "playerData";

    public void Initialize()
    {
        if (PlayerPrefs.HasKey(_playerPrefsKey))
        {
            string playerDataString = PlayerPrefs.GetString(_playerPrefsKey);
            _playerData = JsonUtility.FromJson<PlayerData>(playerDataString);
        }
        else
        {
            _playerData = new PlayerData();
        }
    }

    public int GetPlayerLevel()
    {
        return _playerData.playerLevel;
    }

    public void IncreasePlayerLevel()
    {
        _playerData.playerLevel++;
        SavePlayerData();
    }

    private void SavePlayerData()
    {
        string playerDataString = JsonUtility.ToJson(_playerData);
        PlayerPrefs.SetString(_playerPrefsKey, playerDataString);
    }

    public void ResetPlayerData()
    {
        _playerData = new PlayerData();
        SavePlayerData();
    }
}

[Serializable]
public class PlayerData
{
    public string playerName = "Player";
    public int playerLevel = 1;
}
