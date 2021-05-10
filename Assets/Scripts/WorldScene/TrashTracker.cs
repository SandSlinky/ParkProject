using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashTracker : MonoBehaviour
{
    private static int IDCounter = 0;
    public int thisTrashID = -1;

    public void Reset()
    {
        thisTrashID = IDCounter;
        IDCounter++;
    }

    public static Dictionary<int, bool> trashCollectedDatabase;

    private void Awake()
    {
        if (trashCollectedDatabase == null)
        {
            trashCollectedDatabase = new Dictionary<int, bool>();
        }
    }

    void Start()
    {
        if (trashCollectedDatabase.ContainsKey(thisTrashID))
        {
            if (trashCollectedDatabase[thisTrashID])
            {
                Destroy(gameObject);
            }
            
            else
            {
                trashCollectedDatabase.Add(thisTrashID, false);
            }
        }
    }

    void CallThisWhenCollected()
    {
        trashCollectedDatabase[thisTrashID] = true;
    }    
}
