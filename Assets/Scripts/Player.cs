using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Animator _animator;
    Rigidbody2D _rb;

    [SerializeField][Range(0, 10)] int speed = 4;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue value)
    {
        Vector2 dir = value.Get<Vector2>().normalized;
        if(dir != Vector2.zero)
        {
            _animator.SetFloat("lastX", dir.x);
            _animator.SetFloat("lastY", dir.y);
        }
        _animator.SetFloat("dX", dir.x);
        _animator.SetFloat("dY", dir.y);
        _animator.SetBool("isMoving", dir != Vector2.zero);
        
        _rb.velocity = dir * speed;
    }
}
