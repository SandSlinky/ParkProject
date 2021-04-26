using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigamePause : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseMenuUI;
    [SerializeField] private RowingStartTimer rowingStartTimer;

    void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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
        SceneManager.GetActiveScene();
        SceneManager.LoadScene(2);
        rowingStartTimer.timerSpeed = 1f;
        Resume();
    }

    public void MinigameQuit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Resume();
    }
}
