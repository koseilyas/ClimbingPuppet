using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInterfaceController : MonoBehaviour
{
    [SerializeField] private Canvas _levelFinishedCanvas;
    [SerializeField] private GameObject _levelEndScreen;
    [SerializeField] private GameObject _popupLevelWin;
    [SerializeField] private GameObject _popupLevelLose;

    private void OnEnable()
    {
        PlayerController.OnPlayerDead += PlayerDead;
        PlayerController.OnPlayerWin += PlayerWin;
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerDead -= PlayerDead;
        PlayerController.OnPlayerWin -= PlayerWin;
    }

    private void PlayerWin()
    {
        StartCoroutine(EnableCanvas());
        _popupLevelWin.SetActive(true);
    }
    
    private void PlayerDead()
    {
        StartCoroutine(EnableCanvas());
        _popupLevelLose.SetActive(true);
    }

    private IEnumerator EnableCanvas()
    {
        yield return new WaitForSeconds(1);
        _levelFinishedCanvas.gameObject.SetActive(true);
        _levelEndScreen.gameObject.SetActive(true);
    }


}
