using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BikingPause : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseMenuUI;
    [SerializeField] private ScoreManager scoreManager;
    public AudioSource buttonSound;
    public bool canPause = true;

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

    void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        if (canPause == true && Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        buttonSound.Play();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
        Debug.Log("Game Unpaused");
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
        Debug.Log("Game Paused");
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
