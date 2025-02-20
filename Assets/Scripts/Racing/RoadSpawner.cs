using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawnner : MonoBehaviour
{
    public GameObject road;
    GameObject lastCreatedRoad;

    void Start()
    {
        lastCreatedRoad = SpawnRoad();
    }

    void Update()
    {
        if (RacingGameManager.Instance.isGameStopped)
        {
            return;
        }

        if (lastCreatedRoad.transform.localPosition.y <= -2.8f)
        {
            lastCreatedRoad = SpawnRoad();
        }
    }

    public GameObject SpawnRoad()
    {
        GameObject temp = Instantiate(road, transform);
        temp.transform.SetParent(transform);

        Debug.Log("Road »ý¼ºµÊ");

        return temp;
    }
}
