using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLooker : MonoBehaviour
{
    private enum Mode
    {
        OnStart,
        OnUpdate
    };

    [SerializeField] private Mode _mode;
    
    void Start()
    {
        if (_mode != Mode.OnStart) return;
        transform.forward = Camera.main.transform.forward;
    }

    void Update()
    {
        if (_mode != Mode.OnUpdate) return;
        transform.forward = Camera.main.transform.forward;
    }
}
