using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash1 : MonoBehaviour
{
    [SerializeField] private TrashTracker2 trashTracker2;
    public int trashValue = 1;

    void OnTriggerEnter2D(Collider2D collision)
    {
        trashTracker2.Trash1 = true;
        TrashCollection.instance.ChangeTrash(trashValue);
        Destroy(gameObject);
    }

    private void Start()
    {
        if (trashTracker2.Trash1 == true)
        {
            Destroy(gameObject);
        }
    }
}
