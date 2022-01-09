using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : StateMachineParent
{
    public PlayerIdleState IdleState { get; private set; }
    public PlayerJumpingState JumpingState { get; private set; }
    public PlayerHangingState HangingState { get; private set; }
    public PlayerPuppetState PlayerPuppetState { get; private set; }
    public Rock targetRock;
    public Rock currentRock;
    [SerializeField] private PlayerHand _leftHand, _rightHand;
    [SerializeField] private Animator _animator;
    [SerializeField] private List<Rigidbody> _rigidbodies;
    public static event Action OnPlayerDead;
    public static event Action OnPlayerWin;

    private void OnValidate()
    {
        _rigidbodies = GetComponentsInChildren<Rigidbody>().ToList();
    }

    private void Awake()
    {
        IdleState = new PlayerIdleState(this, _animator,_rigidbodies);
        PlayerPuppetState = new PlayerPuppetState(this,_rigidbodies);
        JumpingState = new PlayerJumpingState(this, _rigidbodies);
        HangingState = new PlayerHangingState(this);
    }

    private void Start()
    {
        ChangeState(IdleState);
    }

    private void OnEnable()
    {
        InputManager.OnRockClicked += TryToClimb;
        PlayerHand.OnReachedToRock += ReachedToRock;
    }

    private void OnDisable()
    {
        InputManager.OnRockClicked -= TryToClimb;
        PlayerHand.OnReachedToRock -= ReachedToRock;
    }

    void TryToClimb(Rock rock)
    {
        if (CurrentState is PlayerIdleState || CurrentState is PlayerHangingState)
        {
            targetRock = rock;
            ChangeState(JumpingState);
            _leftHand.isFreeToClimb = true;
            _rightHand.isFreeToClimb = true;
        }
    }
    
    private void ReachedToRock(PlayerHand playerHand, Rock rock, bool isFinalRock)
    {
        currentRock = rock;
        playerHand.isFreeToClimb = false;
        ChangeState(HangingState);
        if (isFinalRock)
        {
            GameManager.Instance.PlayerWin();
            OnPlayerWin?.Invoke();
        }
    }

    public void ReleasePlayerFromCurrentRock()
    {
        StartCoroutine(currentRock.ReleasePlayer());
    }

    public void Explode(Vector3 explodeForce)
    {
        foreach (var rb in _rigidbodies)
        {
            rb.AddForce(explodeForce);
        }
        ChangeState(PlayerPuppetState);
        OnPlayerDead?.Invoke();
    }
    
    

    public PlayerHand GetFreeHand()
    {
        if (_leftHand.isFreeToClimb && _rightHand.isFreeToClimb)
        {
            float leftHandDistance = Vector3.Distance(_leftHand.transform.position, targetRock.transform.position);
            float rightHandDistance = Vector3.Distance(_rightHand.transform.position, targetRock.transform.position);
            return leftHandDistance < rightHandDistance ? _leftHand : _rightHand;
        }
        return _leftHand.isFreeToClimb ? _leftHand : _rightHand;
    }
}