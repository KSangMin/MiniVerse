using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    Rigidbody2D _rb;
    float speed = 3;

    public virtual void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (PlaneGameManager.Instance.isStart)
        {
            speed += Time.deltaTime / 30;
            _rb.velocity = new Vector3(-speed, 0);
        }
    }
}
