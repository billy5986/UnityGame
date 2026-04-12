using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed = 2f;
    public bool isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(1, 0) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlaying == true)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        }
    }

    public void StartPlay()
    {
        isPlaying = true;
    }
}
