using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // camera will follow this object
    public Transform Target;
    //camera transform
    public Transform camTransform;
    // offset between camera and target
    public Vector3 Offset;
    // change this value to get desired smoothness
    public float SmoothTime = 0.3f;
 
    // This value will change at the runtime depending on target movement. Initialize with zero vector.
    private Vector3 velocity = Vector3.zero;
    private bool _isFollowing = true;
 
    private void Start()
    {
        Offset = camTransform.position - Target.position;
    }

    private void OnEnable()
    {
        PlayerController.OnPlayerDead += StopFollowing;
    }

    private void StopFollowing()
    {
        _isFollowing = false;
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerDead -= StopFollowing;
    }

    private void LateUpdate()
    {
        if (!_isFollowing)
            return;
        Vector3 targetPosition = new Vector3(0,Target.position.y,0) + Offset;
        camTransform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);

    }
}
