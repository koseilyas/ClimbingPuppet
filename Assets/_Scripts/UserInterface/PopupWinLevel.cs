using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupWinLevel : MonoBehaviour
{
    [SerializeField] private Button _nextLevelButton;
    void Start()
    {
        _nextLevelButton.onClick.AddListener(NextLevelClicked);
    }

    private void NextLevelClicked()
    {
        GameManager.Instance.FinishLevel();
    }
}
