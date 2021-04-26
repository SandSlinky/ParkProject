using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RowingFinish : MonoBehaviour
{
    [SerializeField] public RowingStartTimer rowingStartTimer;
    [SerializeField] public RowingTimer rowingTimer;
    [SerializeField] public Canvas retryMenu;
    public AudioSource goalSound;

    private IEnumerator rowingGoalWait()
    {
        yield return new WaitForSecondsRealtime(3f);
        retryMenu.enabled = true;
    }
    
    void Start()
    {
        goalSound = GetComponent<AudioSource>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rowingStartTimer.startCountdown.text = "GOAL!";
        StartCoroutine (rowingGoalWait());
    }
}
