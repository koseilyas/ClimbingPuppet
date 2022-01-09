using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPuppetState : IState
{
    private PlayerController _playerController;
    private List<Rigidbody> _rigidbodies;

    public PlayerPuppetState(PlayerController playerController, List<Rigidbody> rigidbodies)
    {
        _playerController = playerController;
        _rigidbodies = rigidbodies;
    }

    public void Enter()
    {
        foreach (var rigidbody in _rigidbodies)
        {
            rigidbody.velocity = Vector3.zero;
        }
    }

    public void UpdateState()
    {

    }

    public void FixedUpdateState()
    {

    }

    public void Exit()
    {

    }
}