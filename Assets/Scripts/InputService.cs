using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputService : MonoBehaviour
{
    [SerializeField] private float leftRightPlayerDir;
    [SerializeField] private float forwardPlayerDir;

    public event Action OnSave;
    public event Action OnGiveMeMoney;
    public event Action OnEscape;
    public float LeftRightPlayerDir => leftRightPlayerDir;
    public float ForwardPlayerDir => forwardPlayerDir;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        leftRightPlayerDir = Input.GetAxis("Horizontal");
        forwardPlayerDir = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.S))
        {
            OnSave?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            OnGiveMeMoney?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnEscape?.Invoke();
        }
    
}
}
