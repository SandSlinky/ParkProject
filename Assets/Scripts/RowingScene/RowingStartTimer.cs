using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RowingStartTimer : MonoBehaviour
{
    [SerializeField] public float currentTime = 3f;
    [SerializeField] private RowingMovement rowingMovement;
    [SerializeField] public Text startCountdown;
    [SerializeField] private RowingTimer rowingTimer;
    [SerializeField] private MinigamePause minigamePause;
    public AudioSource countdownSound;
    public float timerSpeed = 1f;

    private IEnumerator rowingGo()
    {
        yield return new WaitForSecondsRealtime(1f);
        minigamePause.canPause = true;
        rowingMovement.canMove = true;
        rowingTimer.SetTimer(true);
        startCountdown.text = "";        
    }

    void Start()
    {
        minigamePause.canPause = false;
        countdownSound.Play();
        timerSpeed = 1f;
        rowingMovement.canMove = false;
    }

    private void Update()
    {
        if (timerSpeed == 0f)
        {
            return;
        }
        StartCoroutine(countdownCoroutine());
    }

    private IEnumerator countdownCoroutine()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        currentTime -= timerSpeed * Time.deltaTime;
        startCountdown.text = currentTime.ToString("0");

		if (currentTime <= 0.5)
		{
			timerSpeed = 0f;
			startCountdown.text = "GO!";
			StartCoroutine(rowingGo());
        }
    }
}