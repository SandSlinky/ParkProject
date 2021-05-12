using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikingMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public bool canMove = true;
    Vector2 movement;

    // Jump variables
    private bool isGrounded;
    public Transform bottomPosition;
    public float checkRadius;
    public float jumpForce;
    public LayerMask whatIsGround;


    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        if (isGrounded == true)
            Debug.Log("Grounded!");
    }
   
    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            movement.x = 1;
            isGrounded = Physics2D.OverlapCircle(bottomPosition.position, checkRadius, whatIsGround);

            if(canMove == true && isGrounded == true && Input.GetKeyDown(KeyCode.Space))
            {
                rb.velocity = Vector2.up * jumpForce;
            }
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
}
