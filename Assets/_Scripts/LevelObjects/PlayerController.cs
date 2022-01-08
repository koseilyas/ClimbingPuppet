using UnityEngine;

public class PlayerController : StateMachineParent
{
    public PlayerIdleState IdleState { get; private set; }
    public PlayerJumpingState JumpingState { get; private set; }
    public PlayerHangingState HangingState { get; private set; }
    [SerializeField] private PlayerHand _leftHand, _rightHand;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody[] _rigidbodies; 

    private void Awake()
    {
        IdleState = new PlayerIdleState(this, _animator,_rigidbodies);
    }

    private void Start()
    {
        ChangeState(IdleState);
    }

    private void OnEnable()
    {
        InputManager.OnHandGripClicked += TryToClimb;
    }

    private void OnDisable()
    {
        InputManager.OnHandGripClicked -= TryToClimb;
    }

    void TryToClimb(HandGrip handGrip)
    {
        if (CurrentState is PlayerIdleState || CurrentState is PlayerHangingState)
        {
            
        }
    }
    
    

    private PlayerHand GetFreeHand()
    {
        if (_leftHand.IsFreeToClimb && _rightHand.IsFreeToClimb)
        {
            
        }
        return _leftHand.IsFreeToClimb ? _leftHand : _rightHand;
    }
}