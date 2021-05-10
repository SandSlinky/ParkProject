using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikingPoint : MonoBehaviour
{
    public int pointValue = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.ChangeScore(pointValue);
        }
        
        Destroy(gameObject);
    }
}
