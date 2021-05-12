using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BikingStartTimer : MonoBehaviour
{
    [SerializeField] public float currentTime = 3f;
    [SerializeField] private BikingMovement2 bikingMovement2;
    [SerializeField] public Text startCountdown;
    [SerializeField] public CameraMovement cameraMovement;
    [SerializeField] public BikingPause bikingPause;
    public AudioSource countdownSound;

    public float timerSpeed = 1f;

    private IEnumerator bikingGo()
    {
        yield return new WaitForSecondsRealtime(1f);
        bikingPause.canPause = true;
        bikingMovement2.canMove = true;
        cameraMovement.camMoveEnabled = true;
        startCountdown.text = "";
    }

    private IEnumerator startCountDown()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        currentTime -= timerSpeed * Time.deltaTime;
        startCountdown.text = currentTime.ToString("0");

        if (currentTime <= 0.5)
        {
            timerSpeed = 0f;
            startCountdown.text = "GO!";
            StartCoroutine(bikingGo());
        }
    }
    void Start()
    {
        bikingPause.canPause = false;
        countdownSound.Play();
        timerSpeed = 1f;
        bikingMovement2.canMove = false;
        cameraMovement.camMoveEnabled = false;
    }

    private void Update()
    {
        if (timerSpeed == 0f)
        {
            return;
        }
        StartCoroutine(startCountDown());
    }
}