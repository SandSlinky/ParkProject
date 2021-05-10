using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    public float speed;
    private float movement;
    public bool birdMove = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (birdMove == true)
        {
            movement = -1;
            rb.velocity = new Vector2(movement * speed, rb.velocity.y);
            Debug.Log("Birdmove = true");
        }

        else
        {
            movement = 0;
            Debug.Log ("Birdmove = false");
        }
    }
}
