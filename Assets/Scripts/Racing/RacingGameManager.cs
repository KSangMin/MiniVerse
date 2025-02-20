using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacingGameManager : Singleton<RacingGameManager>
{
    public bool isGameStopped = false;

    public override void Awake()
    {
        isGlobal = false;

        base.Awake();
    }

    public void GameOver()
    {
        isGameStopped = true;
    }
}
