using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryMenu : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject retryMenu;
    [SerializeField] private RowingStartTimer rowingStartTimer;
    public AudioSource buttonSound;

    private IEnumerator restartWait()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.GetActiveScene();
        SceneManager.LoadScene(2);
        rowingStartTimer.timerSpeed = 1f;
        Resume();
    }

    private IEnumerator quitWait()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Vector2 LoadPosition = new Vector2(-29, 20);
        
        transform.position = LoadPosition;
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
