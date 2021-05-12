using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BikingRetry : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject retryMenu;
    [SerializeField] private ScoreManager scoreManager;
    public AudioSource buttonSound;

    private IEnumerator restartWait()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.GetActiveScene();
        SceneManager.LoadScene(3);
        scoreManager.score = 0;
        Resume();
    }

    private IEnumerator quitWait()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        Resume();
    }

    public void Resume()
    {
        buttonSound.Play(); 
        retryMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
        Debug.Log("Game Unpaused");
    }

    public void Restart()
    {
        buttonSound.Play();
        StartCoroutine(restartWait());
    }

    public void MinigameQuit()
    {
        buttonSound.Play();
        StartCoroutine(quitWait());
    }
}
