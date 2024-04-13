using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    [SerializeField] GameObject ufo;

    [SerializeField] float interval_Spawn;

    float timer;

    Vector3 spawnPosition;

    void Start()
    {
        timer = interval_Spawn;
    }

    
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            spawnPosition = new Vector3(Random.Range(-6, 6), 6, 0);

            Instantiate(ufo, spawnPosition, Quaternion.identity);

            timer = interval_Spawn;
        }
    }
}
