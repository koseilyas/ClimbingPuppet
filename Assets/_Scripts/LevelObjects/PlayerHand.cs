using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;
    public bool IsFreeToClimb { get; private set; }
    
    public Rigidbody GetRigidBody()
    {
        return _rigidBody;
    }
}