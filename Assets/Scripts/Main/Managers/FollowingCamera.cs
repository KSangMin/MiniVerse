using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : Singleton<FollowingCamera>
{
    public Camera cam;
    public Transform target;
    public Transform minTransform;
    public Transform maxTransform;

    private Vector2 _minBound;
    private Vector2 _maxBound;

    [Range(1, 10)] public float cameraSpeed = 1.5f;

    public override void Awake()
    {
        isGlobal = false;

        base.Awake();
    }

    void Start()
    {
        cam.transform.position = GameManager.Instance.playerPos;

        _minBound = minTransform.position;
        _maxBound = maxTransform.position;
    }

    void FixedUpdate()
    {
        Vector2 camPos = target.position;

        camPos.x = Mathf.Clamp(camPos.x, _minBound.x, _maxBound.x);
        camPos.y = Mathf.Clamp(camPos.y, _minBound.y, _maxBound.y);

        cam.transform.position = Vector2.Lerp(cam.transform.position, camPos, Time.deltaTime * cameraSpeed);
    }
}
