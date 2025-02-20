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
        if (RacingGameManager.Instance.isGameStopped)
        {
            return;
        }

        Transform target = tracks[curId];
        transform.position = Vector3.Lerp(transform.position, target.position, 0.4f);

        Vector2 distance = target.position - transform.position;
        float angle = Mathf.Clamp((distance.x > 0 ? -distance.magnitude : distance.magnitude) * 15f, -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void OnMove(InputValue value)
    {
        if (RacingGameManager.Instance.isGameStopped)
        {
            return;
        }

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
