using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public Transform followTarget;
    private Transform _camTransform;
    private Vector3 _offset = Vector3.zero;
    [SerializeField]private float _smoothTime = 0.3f;
    private Vector3 _velocity = Vector3.zero;
    private bool _isFollowing = true;
    

    private void OnEnable()
    {
        PlayerController.OnPlayerDead += StopFollowing;
        LevelLoader.OnLevelLoaded += LevelLoaded;
    }

    private void LevelLoaded(int obj)
    {
        _camTransform = Camera.main.transform;
        _offset = _camTransform.position - followTarget.position;
    }

    private void StopFollowing()
    {
        _isFollowing = false;
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerDead -= StopFollowing;
        LevelLoader.OnLevelLoaded -= LevelLoaded;
    }

    private void LateUpdate()
    {
        if (!_isFollowing || followTarget == null)
            return;
        var position = followTarget.position;
        Vector3 targetPosition = new Vector3(position.x,position.y,0) + _offset;
        _camTransform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);

    }
}
