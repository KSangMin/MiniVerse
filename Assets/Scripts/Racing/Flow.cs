using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flow : MonoBehaviour
{
    public float speed = 3f;
    void Start()
    {
        
    }

    void Update()
    {
        if (RacingGameManager.Instance.isGameOver)
        {
            return;
        }

        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
