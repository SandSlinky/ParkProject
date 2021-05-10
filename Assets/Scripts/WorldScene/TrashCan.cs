using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    [SerializeField] private DialogueTrigger dialogueTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if(Input.GetKey(KeyCode.Space))
        {
            dialogueTrigger.TriggerDialogue();
        }
    }
}
