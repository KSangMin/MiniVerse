using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Plane : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rb;

    public float jumpForce = 6f;
    private bool _isDead = false;
    private float _deathCool = 0f;

    public bool godMode = false;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _deathCool = 0.01f;
    }
    private void Update()
    {
        if (_deathCool > 0f)
        {
            _deathCool -= Time.deltaTime;
            Debug.Log(_deathCool);
        }
    }

    private void FixedUpdate()
    {
        if (_isDead) return;

        float angle = Mathf.Clamp(_rb.velocity.y * 10f, -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return;
        if (_isDead) return;

        _isDead = true;
        _deathCool = 1f;

        _animator.SetBool("isDead", true);

        PlaneGameManager.Instance.GameOver();
    }

    public void OnFlap(InputAction.CallbackContext context)
    {
        if (_deathCool <= 0f && context.started)
        {
            if (_isDead)
            {
                PlaneGameManager.Instance.RestartGame();
            }
            else
            {
                Vector3 velocity = _rb.velocity;
                velocity.y += jumpForce;
                _rb.velocity = velocity;
            }
        }
            
    }
}
