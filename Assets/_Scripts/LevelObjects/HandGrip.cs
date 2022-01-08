using System;
using UnityEngine;

public class HandGrip : MonoBehaviour
{
    [SerializeField] private HingeJoint _hingeJoint;
    [SerializeField] private BoxCollider _boxCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerHand playerHand))
        {
            _hingeJoint.connectedBody = playerHand.GetRigidBody();
            _boxCollider.enabled = false;
        }
    }
}