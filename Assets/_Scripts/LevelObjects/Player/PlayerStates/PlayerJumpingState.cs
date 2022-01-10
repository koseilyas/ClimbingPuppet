using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingState : IState
{
    private PlayerController _playerController;
    private PlayerHand _actionHand;
    private List<Rigidbody> _rigidbodies;
    private float _startVelocity = 6f, _bodyVelocity, _handVelocity,_velocityDeacceleration;
    private float _rigidBodiesMultiplier = 0.5f;
    private Vector3 _rockDirection;
    private bool _isJumping;

    public PlayerJumpingState(PlayerController playerController, List<Rigidbody> rigidbodies)
    {
        _playerController = playerController;
        _rigidbodies = rigidbodies;
    }

    public void Enter()
    {
        _velocityDeacceleration = GameManager.Instance.gameSettings.playerSpeedDeacceleration;
        _startVelocity = GameManager.Instance.gameSettings.playerStartingJumpSpeed;
        _bodyVelocity = _startVelocity ;
        _handVelocity = _startVelocity;
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
        DecreaseSpeed();
        Move();
    }

    private void Move()
    {
        _rockDirection = (_playerController.targetRock.GetColliderPos() - _actionHand.transform.position).normalized;
        _actionHand.GetRigidBody().velocity = _rockDirection * _handVelocity;
        foreach (var rb in _rigidbodies)
        {
            rb.velocity = _rockDirection * _bodyVelocity * _rigidBodiesMultiplier;
        }
    }

    private void DecreaseSpeed()
    {
        _bodyVelocity -= Time.fixedDeltaTime * (_velocityDeacceleration * 1.5f);
        _handVelocity -= Time.fixedDeltaTime * _velocityDeacceleration;
        if (_bodyVelocity < 2)
            _isJumping = false;
    }

    public void Exit()
    {
        _isJumping = false;
    }
}