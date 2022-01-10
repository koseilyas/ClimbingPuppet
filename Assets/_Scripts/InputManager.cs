using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static event Action<Rock> OnRockClicked;
    
    private Camera _camera;
    void Awake()
    {
        _camera = Camera.main;
    }
    
    void Update()
    {
#if UNITY_STANDALONE || UNITY_EDITOR
        CheckMouseInput();
#elif UNITY_ANDROID || UNITY_IOS
        CheckTouchInput();
#endif
    }

    private void CheckMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckRayCastHit(Input.mousePosition);
        }
    }
    
    private void CheckTouchInput()
    {
        if (Input.touchCount > 0)
        {
            CheckRayCastHit(Input.GetTouch(0).position);
        }
    }

    private void CheckRayCastHit(Vector3 pos)
    {
        bool hit = Physics.Raycast(_camera.ScreenPointToRay(pos), out RaycastHit hitInfo);
        if (hit)
        {
            if (hitInfo.transform.TryGetComponent(out Rock rock))
            {
                OnRockClicked?.Invoke(rock);
                Log.Write($"clicked to {rock.name}");
            }
        }
    }
}