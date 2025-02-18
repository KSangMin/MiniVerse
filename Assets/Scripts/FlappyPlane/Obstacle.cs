using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : Background
{
    public float maxY = 1.2f;
    public float minY = -1.2f;

    float minSize = 0.5f;
    float maxSize = 4f; 

    public Transform top;
    public Transform bottom;

    public float widthPadding = 4f;

    public override void Start()
    {
        base.Start();

        SetRandomHeight();
    }

    public Vector2 SetRandomInterval(Vector2 lastPos, int count)
    {
        SetRandomHeight();

        Vector2 pos = lastPos + new Vector2(widthPadding, 0);
        pos.y = Random.Range(minY, maxY);

        transform.position = pos;

        return pos;
    }

    public void SetRandomHeight()
    {
        top.localPosition = new Vector2(0, Random.Range(minSize, maxSize) / 2);
        bottom.localPosition = new Vector2(0, -Random.Range(minSize, maxSize) / 2);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Plane plane = collision.GetComponent<Plane>();
        if(plane != null)
        {
            PlaneGameManager.Instance.AddScore(1);
        }
    }
}
