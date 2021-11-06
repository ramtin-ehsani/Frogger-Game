using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float delay = .3f;

    public Transform[] points;
    public GameObject car;

    private float nextTimeToSpawn = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nextTimeToSpawn <= Time.time)
        {
            nextTimeToSpawn = Time.time + delay;
            Spawn();
        }
    }

    void Spawn()
    {
        int randomPoint = Random.Range(0, points.Length);
        Transform spawnPoint = points[randomPoint];
        Instantiate(car, spawnPoint.position, spawnPoint.rotation);
    }
}
