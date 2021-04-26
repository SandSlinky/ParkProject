using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    public int trashValue = 1;
    private static bool trashCollected = false;

    private void Awake()
    {
        if (trashCollected == true)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        TrashCollection.instance.ChangeTrash(trashValue);
        trashCollected = true;
        Destroy(gameObject);
    }
}
