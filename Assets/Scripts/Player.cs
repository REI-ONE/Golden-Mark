using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private Movement _movement;

    private void Awake()
    {
        _movement.Params.Init();
    }

    private void InputRead()
    {
        if (Input.GetKey(KeyCode.D))
            _movement.OnMove(Vector2.right);
        else if (Input.GetKey(KeyCode.A))
            _movement.OnMove(Vector2.left);

        _movement.OnSitDown(Input.GetKey(KeyCode.S));
        _movement.OnJerk(Input.GetKey(KeyCode.LeftShift));

        if (Input.GetKeyDown(KeyCode.Space))
            _movement.OnJump();
    }

    private void Update()
    {
        InputRead();
        _movement.OnUpdate();
    }
}