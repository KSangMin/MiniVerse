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

    public GameObject inateractPanel;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        transform.position = GameManager.Instance.playerPos;
        inateractPanel.SetActive(false);
    }

    private void FixedUpdate()
    {
        if(!DialogueManager.Instance.isDialogueStarted && dir.magnitude > 0)
        {
            Vector2 newPos = (Vector2)transform.position + dir * speed * Time.deltaTime;
            _rb.MovePosition(newPos);
        }
    }

    void OnMove(InputValue value)
    {
        dir = value.Get<Vector2>().normalized;

        if (!DialogueManager.Instance.isDialogueStarted)
        {
            if (dir != Vector2.zero)
            {
                _animator.SetFloat("lastX", dir.x);
                _animator.SetFloat("lastY", dir.y);
            }
            _animator.SetFloat("dX", dir.x);
            _animator.SetFloat("dY", dir.y);
            _animator.SetBool("isMoving", dir != Vector2.zero);
        }
        else _animator.SetBool("isMoving", false);
    }

    void OnInteract(InputValue value)
    {
        Debug.Log("플레이어 F 입력됨");
        if (value.isPressed)
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
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + new Vector3(0, 0.15f), interactRange);
    }

    public void TurnOnInteractPanel()
    {
        inateractPanel.SetActive(true);
    }

    public void TurnOffInteractPanel()
    {
        inateractPanel.SetActive(false);
    }
}
