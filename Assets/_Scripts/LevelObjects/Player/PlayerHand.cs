using System;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;
    public bool isFreeToClimb = true;
    public static event Action<PlayerHand, Rock, bool> OnReachedToRock;

    public Rigidbody GetRigidBody()
    {
        return _rigidBody;
    }

    public void ReachedToRock(Rock rock,bool isFinalRock)
    {
        OnReachedToRock?.Invoke(this,rock,isFinalRock);
    }
}