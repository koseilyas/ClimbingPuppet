using System;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;
    public bool isFreeToClimb = true;
    public static event Action<PlayerHand, HandGrip> OnReachedToHandGrip;

    public Rigidbody GetRigidBody()
    {
        return _rigidBody;
    }

    public void ReachedToHandGrip(HandGrip handGrip)
    {
        OnReachedToHandGrip?.Invoke(this,handGrip);
    }
}