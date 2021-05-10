using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RowingFinish : MonoBehaviour
{
    [SerializeField] public RowingStartTimer rowingStartTimer;
    [SerializeField] public RowingTimer rowingTimer;
    [SerializeField] public RowingMovement rowingMovement;
    public AudioSource goalSound;
    public GameObject retryMenu;

    private IEnumerator rowingGoalWait()
    {
        yield return new WaitForSecondsRealtime(3f);
        rowingMovement.canMove = false;
        retryMenu.SetActive(true);
    }
    
    void Start()
    {
        goalSound = GetComponent<AudioSource>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        goalSound.Play();
        rowingTimer.timerSpeed = 0f;
        rowingStartTimer.startCountdown.text = "GOAL!";
        StartCoroutine (rowingGoalWait());
    }
}
