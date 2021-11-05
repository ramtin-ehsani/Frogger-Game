using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 1f;
    void FixedUpdate()
    {
        var right = transform.up;
        Vector2 forward = new Vector2(right.x, right.y);
        rb.MovePosition(rb.position + forward * Time.fixedDeltaTime * speed);
    }
}
