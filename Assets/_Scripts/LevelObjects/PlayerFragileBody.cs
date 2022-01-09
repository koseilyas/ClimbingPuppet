using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFragileBody : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDeadly deadly))
        {
            deadly.Execute();
            _playerController.Explode();
        }
    }
}
