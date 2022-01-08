using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : IState
{
    private readonly PlayerController _playerController;
    private readonly Animator _animator;
    private readonly List<Rigidbody> _rigidbodies;

    public PlayerIdleState(PlayerController playerController, Animator animator, List<Rigidbody> rigidbodies)
    {
        _playerController = playerController;
        _animator = animator;
        _rigidbodies = rigidbodies;
    }

    public void Enter()
    {
        ChangePhysicsState(false);
    }

    public void UpdateState()
    {
        
    }

    public void FixedUpdateState()
    {
        
    }

    public void Exit()
    {
        _animator.enabled = false;
        ChangePhysicsState(true);
    }

    void ChangePhysicsState(bool enabled)
    {
        foreach (var rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = !enabled;
            rigidbody.useGravity = enabled;
        }
    }
}