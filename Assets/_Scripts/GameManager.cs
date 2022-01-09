using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private LevelLoader _levelLoader;

    private void Start()
    {
        PlayerDataManager.Instance.Initialize();
        _levelLoader.LoadLevel(PlayerDataManager.Instance.GetPlayerLevel());
    }

    public void FinishLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayerWin()
    {
        PlayerDataManager.Instance.IncreasePlayerLevel();
    }
}
