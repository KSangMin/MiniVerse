using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLooper : MonoBehaviour
{
    private int _bgCount = 3;
    private int _obsCount = 0;
    private Vector3 _lastPos = Vector3.zero;

    void Start()
    {
        Obstacle[] obs = FindObjectsOfType<Obstacle>();
        _lastPos= obs[0].transform.position;
        _obsCount = obs.Length;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered: " + collision.name);

        if (collision.CompareTag("BackGround"))
        {
            float bgWidth = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += bgWidth * _bgCount;
            collision.transform.position = pos;
            return;
        }

        Obstacle o = collision.GetComponent<Obstacle>();
        if(o != null)
        {
            _lastPos = o.SetRandomInterval(_lastPos, _obsCount);
        }
    }
}
