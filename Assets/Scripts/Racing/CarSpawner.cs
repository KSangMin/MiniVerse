using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public GameObject[] carPrefabs;
    public List<Sprite> cars;
    public List<Sprite> sTrucks;
    public List<Sprite> lTrucks;
    public List<Transform> tracks;
    float spawnTimer;
    float spawnTime;

    void Update()
    {
        if (RacingGameManager.Instance.isGameOver)
        {
            return;
        }

        spawnTime += Time.deltaTime;

        if (spawnTime >= spawnTimer)
        {
            spawnTime -= spawnTimer;
            spawnTimer = Random.Range(1f, 2f);
            GameObject c;
            
            c = Instantiate(carPrefabs[0], tracks[Random.Range(0, tracks.Count)]);
            c.GetComponent<SpriteRenderer>().sprite = cars[Random.Range(0, cars.Count)];
            c.transform.SetParent(transform);

            //float rate = Random.Range(0, 1f);
            //if(rate < 0.7)
            //{
            //    spawnTime -= 1f;
            //    c = Instantiate(carPrefabs[0], tracks[Random.Range(0, tracks.Count)]);
            //    c.GetComponent<SpriteRenderer>().sprite = cars[Random.Range(0, cars.Count)];
            //}
            //else if(rate < 0.9)
            //{
            //    spawnTime -= 1.2f;
            //    c = Instantiate(carPrefabs[1], tracks[Random.Range(0, tracks.Count)]);
            //    c.GetComponent<SpriteRenderer>().sprite = sTrucks[Random.Range(0, sTrucks.Count)];
            //}
            //else
            //{
            //    spawnTime -= 1.7f;
            //    c = Instantiate(carPrefabs[2], tracks[Random.Range(0, tracks.Count)]);
            //    c.GetComponent<SpriteRenderer>().sprite = lTrucks[Random.Range(0, lTrucks.Count)];
            //}


        }
    }
}
