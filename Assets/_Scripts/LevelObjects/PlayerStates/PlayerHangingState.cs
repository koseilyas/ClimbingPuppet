using System;

public class PlayerHangingState : IState
{
    private PlayerController _playerController;

    public PlayerHangingState(PlayerController playerController)
    {
        _playerController = playerController;
    }

    public void Enter()
    {
        
    }

    public void UpdateState()
    {
        
    }

    public void FixedUpdateState()
    {
        
    }

    public void Exit()
    {
        _playerController.ReleasePlayerFromCurrentGrip();
    }
}