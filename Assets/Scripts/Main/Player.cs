using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Animator _animator;
    Rigidbody2D _rb;

    Vector2 dir;
    [SerializeField][Range(0, 10)] int speed = 4;
    [Range(0, 1f)] public float interactRange = 0.52f;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        transform.position = GameManager.Instance.playerPos;
    }

    private void FixedUpdate()
    {
        if(dir.magnitude > 0)
        {
            Vector2 newPos = (Vector2)transform.position + dir * speed * Time.deltaTime;
            _rb.MovePosition(newPos);
        }
    }

    void OnMove(InputValue value)
    {
        dir = value.Get<Vector2>().normalized;
        if (dir != Vector2.zero)
        {
            _animator.SetFloat("lastX", dir.x);
            _animator.SetFloat("lastY", dir.y);
        }
        _animator.SetFloat("dX", dir.x);
        _animator.SetFloat("dY", dir.y);
        _animator.SetBool("isMoving", dir != Vector2.zero);
    }

    void OnInteract()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + new Vector3(0, 0.15f), interactRange);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Interactable"))
            {
                Interactable interactable = collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    interactable.Interact();
                    GameManager.Instance.playerPos = transform.position;
                    break;
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + new Vector3(0, 0.15f), interactRange);
    }
}
