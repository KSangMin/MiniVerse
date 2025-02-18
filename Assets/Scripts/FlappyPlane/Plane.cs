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

    public bool godMode = false;

    public bool isStart = false;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();

        StartCoroutine(StartTimer());
    }

    private void FixedUpdate()
    {
        if (_isDead) return;

        if (isStart)
        {
            float angle = Mathf.Clamp(_rb.velocity.y * 10f, -90, 90);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return;
        if (_isDead) return;

        _isDead = true;

        _animator.SetBool("isDead", true);

        PlaneGameManager.Instance.GameOver();
    }

    public void OnFlap(InputAction.CallbackContext context)
    {
        if (isStart && context.started)
        {
            Vector3 velocity = _rb.velocity;
            velocity.y += jumpForce;
            _rb.velocity = velocity;
        }  
    }

    public IEnumerator StartTimer()
    {
        _rb.gravityScale = 0;
        yield return new WaitForSeconds(1f);
        PlaneUIManager.Instance.timerText.text = "2";
        yield return new WaitForSeconds(1f);
        PlaneUIManager.Instance.timerText.text = "1";
        yield return new WaitForSeconds(1f);
        PlaneUIManager.Instance.timerText.text = "Start!";
        _rb.gravityScale = 1;
        isStart = true;
        yield return new WaitForSeconds(1f);
        PlaneUIManager.Instance.timerText.text = "";
    }
}
