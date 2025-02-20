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

    public GameObject playerSprite;
    public GameObject riding;
    public Sprite ridingsprite;
    bool isRiding = false;
    public int rideSpeed = 3;

    [Range(0, 1f)] public float interactRange = 0.52f;

    public GameObject interactPanel;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (GameManager.Instance.isRiding) RideOn(); else RideOff();
        transform.position = GameManager.Instance.playerPos;
        interactPanel.SetActive(false);
    }

    private void FixedUpdate()
    {
        if(!DialogueManager.Instance.isDialogueStarted && dir.magnitude > 0)
        {
            Vector2 newPos = (Vector2)transform.position + dir * speed * Time.deltaTime;
            if (isRiding) newPos += dir * rideSpeed * Time.deltaTime;
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
            if (isRiding) _animator.SetBool("isMoving", false);
            else _animator.SetBool("isMoving", dir != Vector2.zero);
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
        interactPanel.SetActive(true);
    }

    public void TurnOffInteractPanel()
    {
        interactPanel.SetActive(false);
    }

    void OnRide(InputValue value)
    {
        if (value.isPressed)
        {
            ToggleRide();
        }
    }

    void ToggleRide()
    {
        if (isRiding)
        {
            RideOff();
        }
        else
        {
            RideOn();
        }

        GameManager.Instance.isRiding = isRiding;
    }

    void RideOn()
    {
        isRiding = true;
        riding.GetComponent<SpriteRenderer>().sprite = ridingsprite;
        playerSprite.transform.localPosition = new Vector3(0, 0.4f, 0);
        riding.GetComponent<BoxCollider2D>().enabled = true;
    }

    void RideOff()
    {
        isRiding = false;
        riding.GetComponent<SpriteRenderer>().sprite = null;
        playerSprite.transform.localPosition = Vector3.zero;
        riding.GetComponent<BoxCollider2D>().enabled = false;
    }

    
}
