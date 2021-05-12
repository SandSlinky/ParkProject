using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowingMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public bool canMove = true;
    Vector2 movement;
    public AudioSource timerSound;
    public AudioSource obstacleSound;

    void Start()
    {
        canMove = true;
    }

    void Update()
    {
        if (canMove == true)
        {
            movement.y = Input.GetAxisRaw("Vertical");
            movement.x = 1;

            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
    }

    private void FixedUpdate()
    {
        // FixedUpdate used for movement, it's called a set number of times per second, making it more reliable than update.
        {
            if (canMove == true)
                rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Timer"))
        {
            timerSound.Play();
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            obstacleSound.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Timer"))
        {
            timerSound.Play();
        }
    }
}
