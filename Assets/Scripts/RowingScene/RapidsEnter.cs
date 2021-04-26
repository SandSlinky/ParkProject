using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidsEnter : MonoBehaviour
{
    [SerializeField] private RowingMovement rowingMovement;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rowingMovement.moveSpeed = 7.5f;
    }
}
