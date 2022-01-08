using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingState : IState
{
    private PlayerController _playerController;
    private PlayerHand _actionHand;
    private List<Rigidbody> _rigidbodies;
    private float _handVelocity = 7;
    private float _rigidBodiesMultiplier = 0.6f;
    private Vector3 _handGripDirection;
    private bool _isJumping;

    public PlayerJumpingState(PlayerController playerController, List<Rigidbody> rigidbodies)
    {
        _playerController = playerController;
        _rigidbodies = rigidbodies;
    }

    public void Enter()
    {
        _actionHand = _playerController.GetFreeHand();
        _rigidbodies.Remove(_actionHand.GetRigidBody());
        _isJumping = true;
    }

    public void UpdateState()
    {
        
    }

    public void FixedUpdateState()
    {
        if(!_isJumping)
            return;
        _handGripDirection = (_playerController.targetHandGrip.transform.position - _actionHand.transform.position).normalized;
        _actionHand.GetRigidBody().velocity = _handGripDirection * _handVelocity;
        foreach (var rb in _rigidbodies)
        {
            rb.velocity = _handGripDirection * _handVelocity * _rigidBodiesMultiplier;
        }
    }

    public void Exit()
    {
        _isJumping = false;
    }
}