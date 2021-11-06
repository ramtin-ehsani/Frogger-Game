using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Car : MonoBehaviour
{
    public Rigidbody2D rb;

    public static float minSpeed = 8f;
    public static float maxSpeed = 12f;
    public float speed = 1f;

    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    void FixedUpdate()
    {
        var right = transform.up;
        Vector2 forward = new Vector2(right.x, right.y);
        rb.MovePosition(rb.position + forward * Time.fixedDeltaTime * speed);
    }
}
