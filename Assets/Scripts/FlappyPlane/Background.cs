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
        _rb.velocity = new Vector3(-speed, 0);
    }

    private void FixedUpdate()
    {
        speed += Time.deltaTime / 10;
        _rb.velocity = new Vector3(-speed, 0);
        Debug.Log(speed);
    }
}
