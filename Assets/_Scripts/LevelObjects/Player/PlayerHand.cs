using System;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;
    public bool isFreeToClimb = true;
    public static event Action<PlayerHand, Rock> OnReachedToRock;

    public Rigidbody GetRigidBody()
    {
        return _rigidBody;
    }

    public void ReachedToRock(Rock rock)
    {
        OnReachedToRock?.Invoke(this,rock);
    }
}