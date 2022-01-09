using System;
using System.Collections;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] private HingeJoint _hingeJoint;
    [SerializeField] private Collider _collider;
    private WaitForSeconds _oneSecond = new WaitForSeconds(1);

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerHand playerHand))
        {
            _hingeJoint.connectedBody = playerHand.GetRigidBody();
            _collider.enabled = false;
            playerHand.ReachedToRock(this);
        }
    }

    public Vector3 GetColliderPos()
    {
        return _collider.transform.position;
    }

    public IEnumerator ReleasePlayer()
    {
        _hingeJoint.connectedBody = null;
        yield return _oneSecond;
        _collider.enabled = true;
    }
}