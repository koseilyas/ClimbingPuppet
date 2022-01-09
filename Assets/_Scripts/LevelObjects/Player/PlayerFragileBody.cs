using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFragileBody : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;

    private void Awake()
    {
        Camera.main.gameObject.GetComponent<CameraManager>().followTarget = transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDeadly deadly))
        {
            deadly.Execute();
            _playerController.Explode(deadly.GetExplodeVector());
        }
    }
}
