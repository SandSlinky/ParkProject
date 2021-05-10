using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashTracker2 : MonoBehaviour
{    
    public bool Trash1 = false;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
