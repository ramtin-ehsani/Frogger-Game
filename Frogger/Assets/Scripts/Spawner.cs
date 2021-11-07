using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float delay = .3f;

    public Transform[] points;
    public GameObject[] cars;

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
        int randomCar = Random.Range(0, cars.Length);
        Transform spawnPoint = points[randomPoint];
        GameObject car = cars[randomCar];
        Instantiate(car, spawnPoint.position, spawnPoint.rotation);
    }
}
