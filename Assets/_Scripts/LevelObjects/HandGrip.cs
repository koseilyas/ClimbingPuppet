using System;
using System.Collections;
using UnityEngine;

public class HandGrip : MonoBehaviour
{
    [SerializeField] private HingeJoint _hingeJoint;
    [SerializeField] private BoxCollider _boxCollider;
    private WaitForSeconds _oneSecond = new WaitForSeconds(1);

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerHand playerHand))
        {
            _hingeJoint.connectedBody = playerHand.GetRigidBody();
            _boxCollider.enabled = false;
            playerHand.ReachedToHandGrip(this);
        }
    }

    public IEnumerator ReleasePlayer()
    {
        _hingeJoint.connectedBody = null;
        yield return _oneSecond;
        _boxCollider.enabled = true;
    }
}