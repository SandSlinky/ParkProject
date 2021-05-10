using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    public int trashValue = 1;
    [SerializeField] public TrashTracker trashTracker;

    void OnTriggerEnter2D(Collider2D collision)
    {
        trashTracker.Reset();
        TrashCollection.instance.ChangeTrash(trashValue);
        Destroy(gameObject);
    }
}
