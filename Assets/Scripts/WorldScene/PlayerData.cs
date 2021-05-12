using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public float[] position;
    public bool setRowingPosition = false;
    [SerializeField] public RowingTransition rowingTransition;
    public float savePosx, savePosy;
    
    public void SaveRowingPosition()
    {
        if (setRowingPosition == true)
        {
            savePosx = rowingTransition.x;
            savePosy = rowingTransition.y;
        }
    }
}
