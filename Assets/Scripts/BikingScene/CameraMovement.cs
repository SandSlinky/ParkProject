using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float camMovementSpeed = 5f;
    public Rigidbody2D rb;
    public bool camMoveEnabled = true;
    Vector2 movement;

    void FixedUpdate()
    {
        if (camMoveEnabled == true)
        {
            movement.x = 1;
            camMovementSpeed = 4.6f;
            rb.MovePosition(rb.position + movement * camMovementSpeed * Time.fixedDeltaTime);
        }
   
        else
        {
            movement.x = 0;
            camMovementSpeed = 0f;
        }
    }
}
