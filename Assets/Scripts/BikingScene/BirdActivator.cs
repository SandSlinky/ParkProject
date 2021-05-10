using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdActivator : MonoBehaviour
{
    [SerializeField] private Bird bird;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bird.birdMove = true;
        }
    }
}
