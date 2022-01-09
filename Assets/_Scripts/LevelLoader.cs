using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LevelLoader : MonoBehaviour
{
    public static event Action<int> OnLevelLoaded;
    private string _levelBaseName = "Level";
    private int _levelNumber;
    public void LoadLevel(int levelNumber)
    {
        _levelNumber = levelNumber;
        string addressableKey = $"{_levelBaseName}{levelNumber}";
        Addressables.InstantiateAsync(addressableKey, transform).Completed += OnLevelInstantiated;
    }

    private void OnLevelInstantiated(AsyncOperationHandle<GameObject> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            OnLevelLoaded?.Invoke(_levelNumber);
        }
        else
        {
            PlayerDataManager.Instance.ResetPlayerData();
            LoadLevel(1);
        }
    }
}
