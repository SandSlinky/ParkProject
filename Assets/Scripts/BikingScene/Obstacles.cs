using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] private CameraMovement cameraMovement;

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        cameraMovement.camMoveEnabled = false;
        cameraMovement.camMovementSpeed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
