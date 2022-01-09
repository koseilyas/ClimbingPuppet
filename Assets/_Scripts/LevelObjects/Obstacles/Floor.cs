using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour, IDeadly
{
    [SerializeField] private Vector3 _explodeForce;
    public void Execute()
    {
        
    }

    public Vector3 GetExplodeVector()
    {
        return _explodeForce;
    }
}
