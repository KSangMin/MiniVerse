using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        if (_animator == null) Debug.Log("애니메이터 없음");
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
    }
}
