using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Vector3 playerPos;

    public bool isRiding = false;

    public Color avatarColor = new Color(1f, 1f, 1f);

    public bool isSecond;
}
