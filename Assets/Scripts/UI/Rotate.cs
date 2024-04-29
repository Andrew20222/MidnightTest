using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private Camera _targetCamera;
    private bool _isFacingCamera = false;

    private void Start()
    {
        _targetCamera = Camera.main;
    }

    private void Update()
    {
        if (!_isFacingCamera)
        {
            transform.LookAt(_targetCamera.transform);
            _isFacingCamera = true;
        }
    }

    public void ResetFacing()
    {
        _isFacingCamera = false;
    }
}