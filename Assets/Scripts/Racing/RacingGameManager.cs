using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacingGameManager : Singleton<RacingGameManager>
{
    public bool isGameOver = false;

    public override void Awake()
    {
        isGlobal = false;

        base.Awake();
    }

    public void GameOver()
    {
        isGameOver = true;
    }
}
