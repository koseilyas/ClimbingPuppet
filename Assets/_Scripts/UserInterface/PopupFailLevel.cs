using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupFailLevel : MonoBehaviour
{
    [SerializeField] private Button _tryAgainButton;
    void Start()
    {
        _tryAgainButton.onClick.AddListener(TryAgainClicked);
    }

    private void TryAgainClicked()
    {
        GameManager.Instance.FinishLevel();
    }
}
