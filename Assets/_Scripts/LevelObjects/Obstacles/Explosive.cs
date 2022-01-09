using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour , IDeadly
{
    [SerializeField] private Vector3 _explodeForce;
    [SerializeField] private GameObject _vfx;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Collider _collider;


    public void Execute()
    {
        _collider.enabled = false;
        _meshRenderer.enabled = false;
        _vfx.SetActive(true);
    }

    public Vector3 GetExplodeVector()
    {
        return _explodeForce;
    }
}