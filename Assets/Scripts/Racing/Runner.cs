using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Runner : MonoBehaviour
{
    public List<Transform> tracks;
    int curId = 2;

    void Start()
    {
        curId = 2;
    }

    void FixedUpdate()
    {
        if (RacingGameManager.Instance.isGameOver)
        {
            return;
        }

        transform.position = Vector3.Lerp(transform.position, tracks[curId].position, 0.4f);
    }

    public void OnMove(InputValue value)
    {
        float right = value.Get<float>();

        if (right > 0)
        {
            curId = Mathf.Min(++curId, 4);
        }
        else if (right < 0)
        {
            curId = Mathf.Max(--curId, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            RacingGameManager.Instance.GameOver();
        }
    }
}
