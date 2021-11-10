using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Frog : MonoBehaviour
{
    public Rigidbody2D rb;

    private float freezeTime = 3f;
    private bool isFreezed;

    private GameObject[] apples;
    private int chosenApple;
    
    // Start is called before the first frame update
    void Start()
    {
        isFreezed = false;
        apples = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject apple in apples)
        {
            apple.SetActive(false);
        }
        chosenApple = Random.Range(0, apples.Length);
        Debug.Log("chose"+chosenApple);
        apples[chosenApple].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.MovePosition(rb.position + Vector2.left);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.MovePosition(rb.position + Vector2.right);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.MovePosition(rb.position + Vector2.up);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.MovePosition(rb.position + Vector2.down);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Apples.apples >= 3)
            {
                isFreezed = true;
                GameObject[] cars = GameObject.FindGameObjectsWithTag("Car");
                foreach (GameObject car in cars)
                {
                    Car renderedCar = car.GetComponent<Car>();
                    renderedCar.speed = 1f;
                }
                Car.minSpeed = 1f;
                Car.maxSpeed = 1f;
                Apples.apples -= 3;
            }
        }

        if (isFreezed)
        {
            freezeTime -= Time.deltaTime;
            if (freezeTime < 0)
            {
                isFreezed = false;
                GameObject[] cars = GameObject.FindGameObjectsWithTag("Car");
                foreach (GameObject car in cars)
                {
                    Car renderedCar = car.GetComponent<Car>();
                    renderedCar.speed = Random.Range(8f, 12f);;
                }
                freezeTime = 3f;
                Car.minSpeed = 8f;
                Car.maxSpeed = 12f;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(TagNames.Car.ToString()))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Score.score = 0;
            Apples.apples = 0;
            freezeTime = 3f;
            isFreezed = false;
            Car.minSpeed = 8f;
            Car.maxSpeed = 12f;
            Debug.Log("HIT!");
        }
        if (other.gameObject.CompareTag(TagNames.End.ToString()))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Score.score += 100;
            freezeTime = 3f;
            isFreezed = false;
            Car.minSpeed = 8f;
            Car.maxSpeed = 12f;
            Debug.Log("END!");
        }
        if (other.gameObject.CompareTag(TagNames.Apple.ToString()))
        {
            Apples.apples += 1;
            apples[chosenApple].SetActive(false);
        }
    }
}
