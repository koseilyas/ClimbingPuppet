using System.Collections.Generic;
using UnityEngine;

public class PlayerController : StateMachineParent
{
    public PlayerIdleState IdleState { get; private set; }
    public PlayerJumpingState JumpingState { get; private set; }
    public PlayerHangingState HangingState { get; private set; }
    public HandGrip targetHandGrip;
    public HandGrip currentHandGrip;
    [SerializeField] private PlayerHand _leftHand, _rightHand;
    [SerializeField] private Animator _animator;
    [SerializeField] private List<Rigidbody> _rigidbodies; 

    private void Awake()
    {
        IdleState = new PlayerIdleState(this, _animator,_rigidbodies);
        JumpingState = new PlayerJumpingState(this, _rigidbodies);
        HangingState = new PlayerHangingState(this);
    }

    private void Start()
    {
        ChangeState(IdleState);
    }

    private void OnEnable()
    {
        InputManager.OnHandGripClicked += TryToClimb;
        PlayerHand.OnReachedToHandGrip += ReachedToHandGrip;
    }

    private void OnDisable()
    {
        InputManager.OnHandGripClicked -= TryToClimb;
        PlayerHand.OnReachedToHandGrip -= ReachedToHandGrip;
    }

    void TryToClimb(HandGrip handGrip)
    {
        if (CurrentState is PlayerIdleState || CurrentState is PlayerHangingState)
        {
            targetHandGrip = handGrip;
            ChangeState(JumpingState);
            _leftHand.isFreeToClimb = true;
            _rightHand.isFreeToClimb = true;
        }
    }
    
    private void ReachedToHandGrip(PlayerHand playerHand, HandGrip handGrip)
    {
        currentHandGrip = handGrip;
        playerHand.isFreeToClimb = false;
        ChangeState(HangingState);
    }

    public void ReleasePlayerFromCurrentGrip()
    {
        StartCoroutine(currentHandGrip.ReleasePlayer());
    }
    
    

    public PlayerHand GetFreeHand()
    {
        if (_leftHand.isFreeToClimb && _rightHand.isFreeToClimb)
        {
            
        }
        return _leftHand.isFreeToClimb ? _leftHand : _rightHand;
    }
}