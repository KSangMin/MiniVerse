using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    public Transform target;
    public Transform minTransform;
    public Transform maxTransform;

    private Vector2 _minBound;
    private Vector2 _maxBound;

    [Range(1, 10)] public float cameraSpeed = 1.5f;

    void Start()
    {
        transform.position = GameManager.Instance.playerPos;

        _minBound = minTransform.position;
        _maxBound = maxTransform.position;
    }

    void FixedUpdate()
    {
        Vector2 cam = target.position;

        cam.x = Mathf.Clamp(cam.x, _minBound.x, _maxBound.x);
        cam.y = Mathf.Clamp(cam.y, _minBound.y, _maxBound.y);

        transform.position = Vector2.Lerp(transform.position, cam, Time.deltaTime * cameraSpeed);
    }
}
