using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
	public int trashId = 0;
    public int trashValue = 1;

    private void Start()
    {
	    trashId = TrashCollection.instance.GetTrashId();
        if (TrashCollection.instance.HasPickedUpTrash(trashId) == true)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        TrashCollection.instance.ChangeTrash(trashId, trashValue);
        Destroy(gameObject);
    }
}
