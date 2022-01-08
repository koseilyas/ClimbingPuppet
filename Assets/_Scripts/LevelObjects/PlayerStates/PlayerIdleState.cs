using UnityEngine;

public class PlayerIdleState : IState
{
    private readonly PlayerController _playerController;
    private readonly Animator _animator;
    private readonly Rigidbody[] _rigidbodies;

    public PlayerIdleState(PlayerController playerController, Animator animator, Rigidbody[] rigidbodies)
    {
        _playerController = playerController;
        _animator = animator;
        _rigidbodies = rigidbodies;
    }

    public void Enter()
    {
        DisablePhysics();
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

    void DisablePhysics()
    {
        foreach (var rigidbody in _rigidbodies)
        {
            rigidbody.isKinematic = true;
            rigidbody.useGravity = false;
        }
    }
}