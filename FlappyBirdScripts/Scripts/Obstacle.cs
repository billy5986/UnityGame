using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(-speed, speed);
        InvokeRepeating("Move", 2, 2);
    }

    // Update is called once per frame
    void Move()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, -rb2d.velocity.y);
    }
}
